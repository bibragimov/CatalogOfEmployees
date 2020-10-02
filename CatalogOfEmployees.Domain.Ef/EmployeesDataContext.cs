using CatalogOfEmployees.Domain.Ef.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CatalogOfEmployees.Domain.Ef
{
    public class EmployeesDataContext : DbContext
    {
        public EmployeesDataContext(DbContextOptions<EmployeesDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}