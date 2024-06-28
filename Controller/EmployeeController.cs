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
    }
}