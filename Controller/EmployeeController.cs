using Microsoft.AspNetCore.Mvc;
using Employeemanagement.Service;
using Employeemanagement.Model;
namespace Employeemanagement.Controller
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetAllEmployees()
        {
            var data = employeeService.GetAllEmployee();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            bool IsEmployeeExist = employeeService.CheckEmployeeExists(employee);
            if (!IsEmployeeExist)
            {
                var data = employeeService.AddEmployee(employee);
                return Created("", data);
            }
            //Status code 409 conflict
            return Conflict(employee.Name + " Employee already exist");
        }
        [HttpGet("GetEmployeeById/{Id}")]
        public IActionResult GetEmployeeById(string Id)
        {
            int userId = Convert.ToInt16(Id);
            var data = employeeService.GetEmployeeById(userId);
            return Ok(data);
        }
        [HttpPatch("Update")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            Employee existingEmployee = employeeService.GetEmployeeById(employee.Id);
            if (existingEmployee is null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Department= employee.Department;
            existingEmployee.City = employee.City;

            Employee result = employeeService.UpdateEmployee(existingEmployee);
            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteEmployeeById(string Id)
        {
            int employeeId = Convert.ToInt16(Id);
            Employee existingEmployee = employeeService.GetEmployeeById(employeeId);
            if (existingEmployee is null)
            {
                return NotFound();
            }
            Employee result = employeeService.DeleteEmployee(existingEmployee);
            return Ok(result);
        }

    }
}