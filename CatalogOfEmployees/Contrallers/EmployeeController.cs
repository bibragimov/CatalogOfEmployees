using System.Collections.Generic;
using CatalogOfEmployees.BusinessLogic.Domain.Contracts;
using CatalogOfEmployees.BusinessLogic.Domain.Dtos;
using CatalogOfEmployees.BusinessLogic.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CatalogOfEmployees.Contrallers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly CsrInformationOptions _csrInformation;

        public EmployeeController(IEmployeeService employeeService, IOptions<CsrInformationOptions> info)
        {
            _employeeService = employeeService;
            _csrInformation = info.Value;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
           return _employeeService.GetAll();
        }

        [HttpGet("{id}")]
        public EmployeeDto Get(int id)
        {
            var employee = _employeeService.Get(id);
            return employee;
        }

        [HttpPost]
        public EmployeeDto Post(CreateEmployee employee)
        {
           var person = _employeeService.Insert(employee);
           return person;
        }

        [HttpPut]
        public IActionResult Put(UpdateEmployee employee)
        {
            _employeeService.Update(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return Ok();
        }
    }
}