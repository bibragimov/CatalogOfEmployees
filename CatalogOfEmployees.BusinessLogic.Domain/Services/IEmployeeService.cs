using CatalogOfEmployees.BusinessLogic.Domain.Contracts;
using CatalogOfEmployees.BusinessLogic.Domain.Dtos;
using System.Collections.Generic;

namespace CatalogOfEmployees.BusinessLogic.Domain.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();

        EmployeeDto Insert(CreateEmployee order);

        EmployeeDto Get(long id);

        void Delete(long id);

        void Update(UpdateEmployee employee);
    }
}