using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Services
{
    public interface IEnterpriseEmployeeService : IBaseService<EnterpriseEmployee>
    {
        Task<EnterpriseEmployee> GetEmployeeByUserId(int userId);
        Task<List<UserModel>> GetEmployeeAsync();
        Task<bool> CreateEmployee(UserRequest userRequest);
        Task<bool> LockEmployee(bool isLock, int userId);
    }
}
