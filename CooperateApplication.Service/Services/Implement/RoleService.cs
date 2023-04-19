using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;

namespace CooperateApplication.Service.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public readonly IRepository<Role> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleService(IRepository<Role> repository, IHttpContextAccessor httpContextAccessor) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<RoleModel>> GetRoleUser(HashSet<int> roleId)
        {
            var roleModels = new List<RoleModel>();
            var roles = await _repository.GetAll();
            foreach (var item in roleId)
            {
                var role = roles.Where(x => x.Id == item).FirstOrDefault();
                roleModels.Add(role.ToModel());
            }
            return roleModels;
        }
    }
}
