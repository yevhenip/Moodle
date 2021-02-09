using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moodle.Core.Interfaces.Data.UnitOfWork;

namespace Moodle.Core.Interfaces.Data.Repositiries
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        ValueTask<TEntity> GetAsync(int id);

        IEnumerable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        
        void Update(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        IUnitOfWork UnitOfWork { get; }

        //public Task<List<TEntity>> ListAsync(bool asNoTracking = true, params Specification<TEntity>[] specifications);
    }
}