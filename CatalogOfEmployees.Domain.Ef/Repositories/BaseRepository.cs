using CatalogOfEmployees.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogOfEmployees.Domain.Ef.Repositories
{
    public class BaseRepository<T> : Reader<T>, IRepository<T> where T : class
    {
        public BaseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            DbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
        }
    }
}