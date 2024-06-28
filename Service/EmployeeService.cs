using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employeemanagement.Context;
using Employeemanagement.Model;

namespace Employeemanagement.Service
{
    public class EmployeeService: IEmployeeService
    {
         private readonly ApplicationDataContext appDataContext;
        public EmployeeService(ApplicationDataContext _appDataContext)
        {
            this.appDataContext = _appDataContext;
        }
        public Employee AddEmployee(Employee employee)
        {
           this.appDataContext.Employees.Add(employee);
             this.appDataContext.SaveChanges();
            return employee;
        }
        public List<Employee> GetAllEmployee()
        {
              return this.appDataContext.Employees.ToList();
        }
        public Employee GetEmployeeById(int employeeId)
        {
             return this.appDataContext.Employees.SingleOrDefault(x => x.Id == employeeId);
        }
         public bool CheckEmployeeExists(Employee employee)
        {
            var data = this.appDataContext.Employees.SingleOrDefault(x => x.Name == employee.Name);
            return (data is not null);
        }
    }
}