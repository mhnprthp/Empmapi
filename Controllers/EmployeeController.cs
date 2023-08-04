using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Dto;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllEmployees(string status = "", int page = 1, int pageSize = 10)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(status, page, pageSize);
            return Ok(employees);
        }

        [HttpGet("{id}")]
         
        public async Task<IActionResult> GetEmployeeSalaryattchbyEid(int id)
        {
            var empalldet =await _employeeService.GetEmpallDetailsByEid(id);
            return Ok (empalldet);
        }

        [HttpPost]
        public int AddEmployee([FromBody] DetailEmpDTO detailEmpDTO)
        {

            return _employeeService.AddEmployee(detailEmpDTO);
        }
        [HttpPut("{id}")]
        public  void EditEmployee(int id, [FromBody] DetailEmpDTO employee)
        {
             _employeeService.EditEmployee(id,employee);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok("Employee deleted successfully.");
        }
    }
}
