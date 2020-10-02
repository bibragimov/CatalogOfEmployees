using AutoMapper;
using CatalogOfEmployees.BusinessLogic.Domain.Dtos;
using CatalogOfEmployees.Domain.Models;

namespace CatalogOfEmployees.MapProfiles
{
    public class EmployeeProfile : Profile
    {
        /// <summary>
        /// </summary>
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();           
        }
    }
}
