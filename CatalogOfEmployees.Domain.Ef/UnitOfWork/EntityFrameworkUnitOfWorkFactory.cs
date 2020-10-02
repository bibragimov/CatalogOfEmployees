using System.Data;
using CatalogOfEmployees.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CatalogOfEmployees.Domain.Ef.UnitOfWork
{
    public class EntityFrameworkUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkUnitOfWorkFactory(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new EntityFrameworkUnitOfWork(_dbContext, isolationLevel);
        }
    }
}