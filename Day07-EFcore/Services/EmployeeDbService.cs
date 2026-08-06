using Day07.Data;
using Day07.Models;
using Microsoft.EntityFrameworkCore;
namespace Day07.Services;
public class EmployeeDbService
{
    private readonly AppDbContext appDbContext;
    public EmployeeDbService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        await appDbContext.Employees.AddAsync(employee);
        await appDbContext.SaveChangesAsync();
        return employee;
    }
    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await appDbContext.Employees.FindAsync(id);
    }
    public async Task<IReadOnlyList<Employee>> GetAllAsync()
    {
        return await appDbContext.Employees.Include(e => e.Department).ToListAsync();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await GetByIdAsync(id);
        if (employee == null)
        {
            return false;
        }

        appDbContext.Employees.Remove(employee);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IReadOnlyList<Employee>> GetByDepartmentAsync(int departmentId)
    {
        return await appDbContext.Employees
            .Where(e => e.DepartmentId == departmentId)
            .Include(e => e.Department)
            .ToListAsync();
    }
}