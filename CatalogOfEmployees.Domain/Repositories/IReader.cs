using System.Linq;

namespace CatalogOfEmployees.Domain.Repositories
{
    public interface IReader<T> where T : class
    {
        IQueryable<T> Get();

        IQueryable<T> GetWithTracking();
    }
}