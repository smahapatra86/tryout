
using Microsoft.EntityFrameworkCore;
using satyawebapp1.Models;

namespace satyawebapp1.Database
{
    public class EmployeeDb : DbContext
    {
        public EmployeeDb(DbContextOptions<EmployeeDb> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}