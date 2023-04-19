using CooperateApplication.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Services
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<T> GetById(int id, params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Get all entity
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Get queryable entity
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeDeleted"></param>
        /// <returns></returns>
        Task<IQueryable<T>> GetQueryable(Expression<Func<T, object>>[]? expression = null, bool includeDeleted = false);

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity"></param>
        Task<T> Insert(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        Task<T> Update(T entity);

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="deleteFromDatabase"></param>
        Task<bool> Delete(int entityId, bool deleteFromDatabase = false);

        /// <summary>
        /// Delte the list of entities
        /// </summary>
        /// <param name="entityIds">The IEnumerable</param>
        Task<bool> Delete(IEnumerable<int> entityIds);

        UserModel GetUserCurent();

        int NumberPage(int totalProduct, int limit);
    }
}
