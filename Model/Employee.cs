using System.ComponentModel.DataAnnotations;

namespace Employeemanagement.Model
{
    public class Employee
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Salary { get; set; }
    public string Department { get; set; }
    public string City { get; set; }
    }
}