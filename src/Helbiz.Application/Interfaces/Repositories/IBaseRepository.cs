using Helbiz.Domain.Common;

namespace Helbiz.Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIDAsync(object id);
        TEntity GetByID(object id);
        Task<TEntity> GetByIDAsNoTrackingAsync(object id);
        TEntity GetByIDAsNoTracking(object id);
        Task<IEnumerable<TEntity>> GetAsync();
        IEnumerable<TEntity> Get();
        Task<IEnumerable<TEntity>> GetAsNoTrackingAsync();
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void DeleteRange(IEnumerable<TEntity> entitiesToDelete);
        void Update(TEntity entityToUpdate);
        void UpdateRange(IEnumerable<TEntity> entitiesToUpdate);
        void Save();
    }
}