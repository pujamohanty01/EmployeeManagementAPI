using System.ComponentModel.DataAnnotations;

namespace Employeemanagement.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Role { get; set; } 
    }
}