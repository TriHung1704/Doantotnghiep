using CooperateApplication.Repositories.Context;
using CooperateApplication.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace CooperateApplication.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CooperationDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(CooperationDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task<bool> Delete(int entityId, bool deleteFromDatabase = false)
        {
            try
            {
                if (entityId == 0)
                {
                    return false;
                }
                T entity = _table.Find(entityId);
                //_context.Attach(entity);
                if (deleteFromDatabase)
                { 
                    _table.Remove(entity);
                }
                else
                {
                    entity.IsDeleted = true;
                    _context.Entry(entity).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public async Task<bool> Delete(IEnumerable<int> entityIds)
        {
            try
            {
                if (!entityIds.Any())
                {
                    throw new ArgumentNullException("entity");
                }

                var entities = new List<T>();
                foreach (var entityId in entityIds)
                {
                    T entity = _table.Find(entityId);
                    _table.Remove(entity);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] include)
        {
            var result = new List<T>();
            if (include.Count() != 0)
            {
                foreach (var item in include)
                {
                    result = await _table.Where(p => p.IsDeleted == false).OrderByDescending(x => x.Id).Include(item).ToListAsync();
                }
            }
            else
            {
                result = await _table.Where(p => p.IsDeleted == false).OrderByDescending(x => x.Id).ToListAsync();
            }
               
            return result;
        }

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] include)
        {
            var result = _table.Where(x => x.Id == id);
            foreach (var item in include)
            {
                result = result.Include(item);
            }
            return await result.FirstOrDefaultAsync();
        }

        public async Task<IQueryable<T>> GetQueryable(Expression<Func<T, object>>[] expression = null, bool includeDeleted = false)
        {
            var query = from b in _table select b;
            
            if (expression != null)
            {
                foreach (var item in expression)
                {
                    query = query.Include(item);
                }
            }
            if (!includeDeleted)
            {
                query = query.Where(p => !p.IsDeleted);
            }

            var result = (await query.ToListAsync()).OrderByDescending(x => x.Id);
            return result.AsQueryable();
        }

        public async Task<T> Insert(T entity)
        {
            entity.CreateAt = DateTime.UtcNow;
            _table.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                var entry = _table.FirstOrDefault(s => s.Id == entity.Id);
                if (entry != null)
                {
                    entity.UpdateAt = DateTime.UtcNow;
                    _context.Entry(entry).CurrentValues.SetValues(entity);
                }
                else
                {
                    entity.Id = 0;
                    entity.CreateAt = DateTime.UtcNow;
                    _table.Add(entity);
                }
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
