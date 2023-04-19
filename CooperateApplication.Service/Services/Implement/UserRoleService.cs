using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;

namespace CooperateApplication.Service.Services
{
    public class UserRoleService : BaseService<UserRole>, IUserRoleService
    {
        public readonly IRepository<UserRole> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRoleService(IRepository<UserRole> repository, IHttpContextAccessor httpContextAccessor) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<UserRoleModel>> GetUserRoles(int userId)
        {
            var userRoles = await _repository.GetAll();
            return userRoles.Where(ur=> ur.UserId == userId).ToList().ToListModel();
        }
    }
}
