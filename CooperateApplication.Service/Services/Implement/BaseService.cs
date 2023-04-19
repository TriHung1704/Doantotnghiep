using CooperateApplication.Repositories.Entities;
using CooperateApplication.Repositories.Repository;
using CooperateApplication.Service.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public readonly IRepository<T> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseService(IRepository<T> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Delete(int entityId, bool deleteFromDatabase = false)
        {
            return await _repository.Delete(entityId, deleteFromDatabase);
        }

        public async Task<bool> Delete(IEnumerable<int> entityIds)
        {
            return await _repository.Delete(entityIds);
        }

        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] include)
        {
            return await _repository.GetAll(include);
        }

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] include)
        {
            return await _repository.GetById(id, include);
        }

        public async Task<IQueryable<T>> GetQueryable(Expression<Func<T, object>>[] expression = null, bool includeDeleted = false)
        {
            return await _repository.GetQueryable(expression, includeDeleted);
        }

        public async Task<T> Insert(T entity)
        {
            return await _repository.Insert(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }
        public UserModel GetUserCurent()
        {
            //var claimsPrincipal = GetPrincipalFromExpiredToken(accessToken);
            //var id = claimsPrincipal.FindFirst("Id")?.Value;
            //var userName = claimsPrincipal.FindFirst("UserName")?.Value;
            //var fullName = claimsPrincipal.FindFirst("FullName")?.Value;
            if (_httpContextAccessor.HttpContext.User.FindFirst("Id") == null)
            {
                return new UserModel();
            }
            var id = _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
            var userName = _httpContextAccessor.HttpContext.User.FindFirst("UserName").Value;
            var fullName = _httpContextAccessor.HttpContext.User.FindFirst("FullName").Value;
            var enterpriseId = _httpContextAccessor.HttpContext.User.FindFirst("EnterpriseId").Value;
            return new UserModel() { Id = Int16.Parse(id), UserName = userName, FullName = fullName, EnterpriseId = Int16.Parse(enterpriseId) };
        }

        public int NumberPage(int total, int limit)
        {
            float numberpage = total / limit;
            return (int)Math.Ceiling(numberpage + 0.5);
        }
    }
}
