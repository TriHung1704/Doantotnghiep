using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CooperateApplication.Service.Services
{
    public class LoginService : BaseService<User>, ILoginService
    {
        public readonly IConfiguration _configuration;
        public readonly IRepository<User> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginService(IRepository<User> repository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, httpContextAccessor)
        {
            _configuration = configuration;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Check login with user name and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserModel> Login(string userName, string password)
        {
            var users = await _repository.GetQueryable();
            var user = users.Where(us => us.UserName == userName).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            bool verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (user != null && verified)
            {
                return user.ToModel();
            }
            return null;
        }

        /// <summary>
        /// Create token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<AthenticationResponse> LoginCreateToken(UserModel user)
        {
            var tokenString = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();
            int.TryParse(_configuration["Jwt:RefreshTokenValidityInDays"], out int refreshTokenValidityInDay);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDay);

            await _repository.Update(user.ToEntity());
            var response = new AthenticationResponse(tokenString, refreshToken);
            return response;
        }

        private string GenerateJwtToken(UserModel user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim("FullName", user.FullName == null ? "No Name" : user.FullName));
            claims.Add(new Claim("UserName", user?.UserName));
            claims.Add(new Claim("EnterpriseId", user?.EnterpriseId.ToString()));

            user.RoleModels.ToList().ForEach(role => claims.Add(new Claim("Roles", role.RoleName)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                signingCredentials: signIn);
            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return stringToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            var respose = Convert.ToBase64String(randomNumber);
            return respose;
        }

        public async Task<AthenticationResponse> RefreshToken(AthenticationResponse athenticationResponse)
        {
            var principal = GetPrincipalFromExpiredToken(athenticationResponse.AccessToken);
            var userId = Int32.Parse(principal.FindFirst("Id")?.Value);
            var user = await _repository.GetById(userId);


            if (principal == null || user == null || user.RefreshToken != athenticationResponse.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new Exception("Invalid access token or refresh token");
            }
            var newToken = GenerateNewJwtToken(principal.Claims.ToList());
            return new AthenticationResponse(newToken, user.RefreshToken);
        }

        private string GenerateNewJwtToken(List<Claim> authClaims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                authClaims,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                signingCredentials: signIn);
            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return stringToken;
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }
    }
}
