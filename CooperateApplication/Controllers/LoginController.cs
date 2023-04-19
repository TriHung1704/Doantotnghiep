using CooperateApplication.Service.Model;
using CooperateApplication.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CooperateApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        private readonly IEnterpriseEmployeeService _enterpriseEmployeeService;

        public LoginController(
            ILoginService loginService,
            IUserRoleService userRoleService,
            IRoleService roleService,
            IEnterpriseEmployeeService enterpriseEmployeeService)
        {
            _loginService = loginService;
            _userRoleService = userRoleService;
            _roleService = roleService;
            _enterpriseEmployeeService = enterpriseEmployeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.UserName)||string.IsNullOrEmpty(userModel.Password)) return BadRequest();
            var user = await _loginService.Login(userModel.UserName, userModel.Password);
            if (user != null)
            {
                var userRoles = await _userRoleService.GetUserRoles(user.Id);
                HashSet<int> userIds = userRoles.Select(x => x.UserId).ToHashSet();
                HashSet<int> roleIds = userRoles.Select(x => x.RoleId).ToHashSet();

                var roles = await _roleService.GetRoleUser(roleIds);
                user.RoleModels = roles;

                if (roles.Select(x=> x.RoleName).Contains("EmployeeHRM") 
                    || roles.Select(x => x.RoleName).Contains("EmployeeMentor")
                    || roles.Select(x => x.RoleName).Contains("EmployeeAdmin"))
                {
                    var enterprise = await _enterpriseEmployeeService.GetEmployeeByUserId(user.Id);
                    user.EnterpriseId = enterprise.EnterpriseId;
                }
                var responseToken = await _loginService.LoginCreateToken(user);
                return Ok(responseToken);
            }
            else
            {
                return NotFound("Invalid credentials");
            }
        }

        [Route("refresh-token")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken(AthenticationResponse athenticationResponse)
        {     
            try
            {
                if (athenticationResponse is null || string.IsNullOrEmpty(athenticationResponse.AccessToken) || string.IsNullOrEmpty(athenticationResponse.RefreshToken))
                {
                    return BadRequest("Invalid client request");
                }
                var tokenRefresh = await _loginService.RefreshToken(athenticationResponse);
                return Ok(tokenRefresh);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
