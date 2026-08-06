
using Day07.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Day07.Data;
using Day07.Services;
namespace Day07;

public class Program
{
    public static async Task Main(string[] args)
    {
        //1. tạo ra một ServiceCollection chứa DI 
        ServiceCollection services = new ServiceCollection();
        //2 . đăng ký DbContext và EmployeeDbService vào DI container
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=employees.db"));
        services.AddScoped<EmployeeDbService>();
        //3. build serviceProvider từ ServiceCollection
        var serviceProvider = services.BuildServiceProvider();
        //4. tạo scope để sử dụng các service từ DI container
        using var scope = serviceProvider.CreateScope();
        //5. lấy ra các service từ scope
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var employeeService = scope.ServiceProvider.GetRequiredService<EmployeeDbService>();
        var engineering = await dbContext.Departments.FirstOrDefaultAsync(d => d.Name == "Engineering");
        var sales = await dbContext.Departments.FirstOrDefaultAsync(d => d.Name == "Sales");
        if(engineering == null || sales == null)
        {
            if (engineering == null)
            {
                engineering = new Department("Engineering");
                await dbContext.Departments.AddAsync(engineering);
            }
            if (sales == null)
            {
                sales = new Department("Sales");
                await dbContext.Departments.AddAsync(sales);
            }
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Da tao va luu 2 department vao DB.");
        }
        else
        {
            Console.WriteLine("Department da ton tai, bo qua seed.");
        }

        var hasEmployees = await dbContext.Employees.AnyAsync();
        if (!hasEmployees)
        {
            var employeesToSeed = new List<Employee>
            {
                new FullTimeEmployee("Alice Nguyen", "alice.nguyen@example.com", DateTime.Today.AddYears(-3), 25000000m, 4000000m)
                {
                    DepartmentId = engineering!.Id
                },
                new FullTimeEmployee("Bob Tran", "bob.tran@example.com", DateTime.Today.AddYears(-2), 22000000m, 2000000m)
                {
                    DepartmentId = sales!.Id
                },
                new PartTimeEmployee("Charlie Le", "charlie.le@example.com", DateTime.Today.AddMonths(-9), 150000m, 80m)
                {
                    DepartmentId = engineering!.Id
                },
                new Intern("Daisy Pham", "daisy.pham@example.com", DateTime.Today.AddMonths(-4), 5000000m)
                {
                    DepartmentId = sales!.Id
                }
            };

            foreach (var employee in employeesToSeed)
            {
                await employeeService.AddEmployeeAsync(employee);
            }

            Console.WriteLine("Da seed 4 employee vao DB qua EmployeeDbService.");
        }
        else
        {
            Console.WriteLine("Employee da ton tai, bo qua seed.");
        }

        var allEmployees = await employeeService.GetAllAsync();
        using (var freshScope = serviceProvider.CreateScope())
        {
            var freshService = freshScope.ServiceProvider.GetRequiredService<EmployeeDbService>();
            var freshEmployees = await freshService.GetAllAsync();
            Console.WriteLine("\n=== Test voi DbContext MOI (khong con gi trong bo nho) ===");
            foreach (var e in freshEmployees)
                Console.WriteLine($"{e} - Department: {e.Department?.Name ?? "NULL"}");
        }
        Console.WriteLine("\n=== Toan bo employee doc tu DB ===");
        foreach (var employee in allEmployees)
        {
            Console.WriteLine($"{employee} - DepartmentId: {employee.DepartmentId} - department: {employee.Department?.Name}");
        }

        var engineeringEmployees = await employeeService.GetByDepartmentAsync(engineering!.Id);
        Console.WriteLine($"\n=== Employee phong Engineering (DepartmentId = {engineering.Id}) ===");
        foreach (var employee in engineeringEmployees)
        {
            Console.WriteLine($"{employee} - DepartmentId: {employee.DepartmentId} - department: {employee.Department?.Name}");
        }

        var existingId = allEmployees.FirstOrDefault()?.Id;
        if (existingId.HasValue)
        {
            var deletedExisting = await employeeService.DeleteAsync(existingId.Value);
            Console.WriteLine($"\nDeleteAsync voi Id ton tai ({existingId.Value}): {deletedExisting}");
        }

        var nonExistingId = -999;
        var deletedNonExisting = await employeeService.DeleteAsync(nonExistingId);
        Console.WriteLine($"DeleteAsync voi Id khong ton tai ({nonExistingId}): {deletedNonExisting}");

        var afterDelete = await employeeService.GetAllAsync();
        Console.WriteLine("\n=== Danh sach sau khi test delete ===");
        foreach (var employee in afterDelete)
        {
            Console.WriteLine($"{employee} - DepartmentId: {employee.DepartmentId} - department: {employee.Department?.Name}");
        }
    }
}

