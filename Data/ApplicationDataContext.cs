using Microsoft.EntityFrameworkCore; 
using Employeemanagement.Model;


namespace Employeemanagement.Context
{
    public class ApplicationDataContext: DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> option): base(option)
        {
        }
        public DbSet<User> Users {get; set;}
        public DbSet<Employee> Employees {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            // Seed initial data
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1, 
                    Name = "John Doe", 
                    EmailId = "john@example.com", 
                    Password = "Password123!", 
                    Role = "Admin" 
                },
                new User 
                { 
                    Id = 2, 
                    Name = "Jane Smith", 
                    EmailId = "jane@example.com", 
                    Password = "Password123!", 
                    Role = "User" 
                }
            );
        }
    }

}