using System.Linq;
using CatalogOfEmployees.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogOfEmployees.Domain.Ef.Repositories
{
    public class Reader<T> : IReader<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public Reader(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return DbSet.AsNoTracking();
        }

        public IQueryable<T> GetWithTracking()
        {
            return DbSet;
        }
    }
}