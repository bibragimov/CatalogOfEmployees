using CatalogOfEmployees.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogOfEmployees.Domain.Ef.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired().HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired().HasColumnName("LastName");
            builder.Property(x => x.MiddleName).HasMaxLength(100).IsRequired().HasColumnName("MiddleName");
            builder.Property(x => x.MobilePhone).IsRequired(false).HasColumnName("MobilePhone");
            builder.Property(x => x.Email).IsRequired(false).HasColumnName("Email");
            builder.Property(x => x.State).IsRequired(false).HasColumnName("State");
            //builder.Property(x => x.Photo).IsRequired(false).HasColumnName("Photo");
        }
    }
}