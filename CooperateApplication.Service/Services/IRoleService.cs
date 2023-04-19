using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;

namespace CooperateApplication.Service.Services
{
    public interface IRoleService : IBaseService<Role>
    {
        /// <summary>
        /// get list role of user by role id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<RoleModel>> GetRoleUser(HashSet<int> roleId);
    }
}
