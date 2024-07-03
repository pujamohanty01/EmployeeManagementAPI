using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employeemanagement.Model;

namespace Employeemanagement.Service
{
    public interface IEmployeeService
    {
        Employee AddEmployee(Employee employee);
        List<Employee> GetAllEmployee();
        Employee GetEmployeeById(int employeeId);
        bool CheckEmployeeExists(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(Employee employee);
    }
}