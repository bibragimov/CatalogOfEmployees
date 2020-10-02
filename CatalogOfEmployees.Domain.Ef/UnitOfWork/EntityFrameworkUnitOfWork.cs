using System;
using System.Data;
using CatalogOfEmployees.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CatalogOfEmployees.Domain.Ef.UnitOfWork
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IDbContextTransaction _transaction;

        public EntityFrameworkUnitOfWork(DbContext dbContext, IsolationLevel isolationLevel)
        {
            _dbContext = dbContext;
            _transaction = dbContext.Database.BeginTransaction(isolationLevel);
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                Rollback();

                var message = ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                    message += ex.InnerException.Message +
                               Environment.NewLine + ex.InnerException.StackTrace;

                throw new Exception(message);
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}