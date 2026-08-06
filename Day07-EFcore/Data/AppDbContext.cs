using Microsoft.EntityFrameworkCore;
using Day07.Models;
namespace Day07.Data;
public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
    public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
    public DbSet<Intern> Interns { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}