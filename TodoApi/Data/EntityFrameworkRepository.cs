using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data {
        public class EntityFrameworkRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext _dbContext;
        public EntityFrameworkRepository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            _dbContext = dbContext;
        }
        protected DbContext DbContext
        {
            get { return _dbContext; }
        }
        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Add(entity);
        }
        public TEntity GetById(TKey id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }
        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();

        }
        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetEntities() {
            return DbContext.Set<TEntity>();
        }

        public void SaveChanges() {
            DbContext.SaveChanges();
        }
    }
}