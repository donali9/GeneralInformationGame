using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GeneralInformationGame.Server.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly GameDbContext Context;

        public Repository(GameDbContext dbContext)
        {
            this.Context = dbContext;
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity? Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            if (include != null)
                return include(Context.Set<TEntity>()).FirstOrDefault(expression);
            else
                return Context.Set<TEntity>().FirstOrDefault(expression);
            //return model != null ? model : null;

        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }
    }
}
