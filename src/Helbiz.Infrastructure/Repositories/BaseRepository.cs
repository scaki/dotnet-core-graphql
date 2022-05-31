using Helbiz.Application.Interfaces.Repositories;
using Helbiz.Domain.Common;
using Helbiz.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Helbiz.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public ApplicationDbContext Context;
        public DbSet<TEntity> DbSet;

        protected BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        protected BaseRepository()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return DbSet.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsNoTrackingAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIDAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIDAsNoTrackingAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual TEntity GetByIDAsNoTracking(object id)
        {
            var entity = DbSet.Find(id);
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            DbSet.Remove(entityToDelete);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entitiesToDelete)
        {
            foreach (TEntity entity in entitiesToDelete)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
            }

            DbSet.RemoveRange(entitiesToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entitiesToUpdate)
        {
            foreach (TEntity entity in entitiesToUpdate)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}