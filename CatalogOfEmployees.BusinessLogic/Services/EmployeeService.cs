using AutoMapper;
using CatalogOfEmployees.BusinessLogic.Domain.Contracts;
using CatalogOfEmployees.BusinessLogic.Domain.Dtos;
using CatalogOfEmployees.BusinessLogic.Domain.Services;
using CatalogOfEmployees.Domain.Models;
using CatalogOfEmployees.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CatalogOfEmployees.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(long id)
        {
            var employee = _repository.Get().FirstOrDefault(x => x.Id == id);
            if(employee != null)
            {
                _repository.Remove(employee);
                _repository.SaveChanges();
            }
        }

        public EmployeeDto Get(long id)
        {
           var employee = _repository.Get().FirstOrDefault(x => x.Id == id);

            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public List<EmployeeDto> GetAll()
        {
            var employees = _repository.Get().ToList();

            return _mapper.Map<List<Employee>, List<EmployeeDto>>(employees);
        }

        public EmployeeDto Insert(CreateEmployee employee)
        {
            var person = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                Email = employee.Email,
                MobilePhone = employee.MobilePhone,
                State = employee.State
            };

            _repository.Add(person);
            _repository.SaveChanges();

            return _mapper.Map<Employee, EmployeeDto>(person);
        }

        public void Update(UpdateEmployee employee)
        {
            var person = _repository.Get().FirstOrDefault(x => x.Id == employee.Id);
            if(person != null)
            {
                person.LastName = employee.LastName;
                person.FirstName = employee.FirstName;
                person.MiddleName = employee.MiddleName;
                person.MobilePhone = employee.MobilePhone;
                person.State = employee.State;
                person.Email = employee.Email;

                _repository.Update(person);

                _repository.SaveChanges();
            }         
        }
    }
}