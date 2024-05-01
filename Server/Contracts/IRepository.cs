using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GeneralInformationGame.Server.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? Get(int id);
        TEntity? Get(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
    }
}
