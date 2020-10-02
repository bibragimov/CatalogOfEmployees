using System;

namespace CatalogOfEmployees.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Rollback();
        void Commit();
    }
}