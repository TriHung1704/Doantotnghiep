using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;

namespace CooperateApplication.Service.Services
{
    public interface IUserRoleService : IBaseService<UserRole>
    {
        Task<List<UserRoleModel>> GetUserRoles(int userId);
    }
}
