using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure._Utilities
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ShopContext _shopContext;

        public BaseRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void Add(TEntity entity)
        {
            _shopContext.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _shopContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(ICollection<TEntity> entities)
        {
            await _shopContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _shopContext.Set<TEntity>().Any(expression);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _shopContext.Set<TEntity>().AnyAsync(expression);
        }

        public TEntity? Get(long id)
        {
            return _shopContext.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id));
        }

        public async Task<TEntity?> GetAsync(long id)
        {
            return await _shopContext.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<TEntity?> GetTracking(long id)
        {
            return await _shopContext.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

        }
        public async Task<int> Save()
        {
            return await _shopContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _shopContext.Update(entity);
        }
    }
}
