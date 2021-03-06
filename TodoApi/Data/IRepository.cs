using System.Linq;

namespace TodoApi.Data
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity GetById(TKey id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IQueryable<TEntity> GetEntities();

        void SaveChanges();
    }
}