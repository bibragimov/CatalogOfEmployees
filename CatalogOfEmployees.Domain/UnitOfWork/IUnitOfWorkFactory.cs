using System.Data;

namespace CatalogOfEmployees.Domain.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
        IUnitOfWork Create(IsolationLevel isolationLevel);
    }
}