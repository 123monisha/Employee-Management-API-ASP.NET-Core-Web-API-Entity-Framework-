using EmployeeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeeAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

      
    }
}
