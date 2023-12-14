using Getri_API_Dapper.Models;
using Getri_API_Dapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Getri_API_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        
        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        [HttpGet("GetAllEpmloyees")]
        public List<Employee> GetAllEpmloyeeData()
        {
            return employeeRepository.GetAllEmployees();            
        }

        [HttpGet("GetAllEmployeeById")]
        public Employee GetEmployeeById(int empId)
        {
            return employeeRepository.GetEmployeeId(empId);
        }

        [HttpPost("InsertEmployee")]
        public int AddNewEmployee(Employee employee)
        {
            return employeeRepository.AddEmployee(employee);
        }

        [HttpPut("UpdateEmployee")]
        public int UpdateEmployee(Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee);
        }

        [HttpDelete("DeleteEmployee")]
        public int DeleteEmployee(int empId)
        {
            return employeeRepository.DeleteEmployee(empId);
        }
    }
}
