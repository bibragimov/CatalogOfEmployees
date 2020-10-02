namespace CatalogOfEmployees.Domain.Repositories
{
    public interface IRepository<T> : IReader<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void SaveChanges();
    }
}