using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;
using static CooperateApplication.Repositories.Enums.CooperateEnums;

namespace CooperateApplication.Service.Services
{
    public class EnterpriseEmployeeService : BaseService<EnterpriseEmployee>, IEnterpriseEmployeeService
    {
        public readonly IRepository<EnterpriseEmployee> _repository;
        public readonly IRepository<User> _userRepository;
        public readonly IRepository<UserRole> _userRoleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EnterpriseEmployeeService(IRepository<EnterpriseEmployee> repository
            , IHttpContextAccessor httpContextAccessor
            , IRepository<User> userRepository,
            IRepository<UserRole> userRoleRepository) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<bool> CreateEmployee(UserRequest userRequest)
        {
            try
            {
                var user = userRequest.ToEntity();
                user.UserType = UserTypeName.Employee;
                user.Password = BCrypt.Net.BCrypt.HashPassword("1234");
                var users = await _userRepository.GetAll();
                if (users.Any(x=>x.UserName == user.UserName))

                {
                    return false;
                }
                var userResponse = await _userRepository.Insert(user);

                var userRole = new UserRole() { UserId = userResponse.Id, RoleId = (int)userRequest.EmployeeType };
                await _userRoleRepository.Insert(userRole);

                var employeeEnterprise = new EnterpriseEmployee() { UserId = userResponse.Id, EnterpriseId = GetUserCurent().EnterpriseId };
                await _repository.Insert(employeeEnterprise);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<List<UserModel>> GetEmployeeAsync()
        {
            try
            {
                var userCurent = GetUserCurent();
                var employeeEnterprises = (await _repository.GetQueryable()).Where(x => x.EnterpriseId == userCurent.EnterpriseId).ToList();
                var users = new List<UserModel>();
                foreach (var userId in employeeEnterprises.Select(x=>x.UserId))
                {
                    var user = await _userRepository.GetById(userId);
                    users.Add(user.ToModel());
                }
                return users;
            }
            catch
            {
                throw new NotImplementedException();
            }
            
        }

        public async Task<EnterpriseEmployee> GetEmployeeByUserId(int userId)
        {
            var enterpriseEmployees = await _repository.GetQueryable();
            var entE = enterpriseEmployees.Where(x => x.UserId == userId).FirstOrDefault();
            return entE;
        }

        public async Task<bool> LockEmployee(bool isLock, int userId)
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                if (user == null) { return false; }
                user.IsDeleted = isLock;
                await _userRepository.Update(user);
                return true;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
