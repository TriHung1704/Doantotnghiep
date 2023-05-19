using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Service.Services
{
    public interface IEnterpriseEmployeeService : IBaseService<EnterpriseEmployee>
    {
        Task<EnterpriseEmployee> GetEmployeeByUserId(int userId);
        Task<List<UserModel>> GetEmployeeAsync();
        Task<EnterpriseModels> GetListEnterprisesAsync(int page);
        Task<bool> CreateEmployee(UserRequest userRequest);
        Task<bool> CreateEnterprise(EnterpriseModel enterpriseModel);
        Task<bool> LockEmployee(bool isLock, int userId);
        Task<bool> LockEnterprise(bool isLock, int enterpriseId);
        Task<bool> UpdateEnterprise(EnterpriseModel enterpriseModel);
        Task<EnterpriseModel> GetEnterprisesAsync(int id);
    }
}
