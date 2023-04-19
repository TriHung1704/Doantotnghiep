using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;

namespace CooperateApplication.Service.Services
{
    public class MajorsService : BaseService<Majors>, IMajorsService
    {
        public readonly IRepository<Majors> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MajorsService(IRepository<Majors> repository, IHttpContextAccessor httpContextAccessor) : base(repository, httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
