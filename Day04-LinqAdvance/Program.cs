using Day04.Models;
using Day04.Services;
using Day04.Repositories;
namespace Day04;

public class Program
{
    public static void Main(string[] args)
    {
        var employeeRepository = new InMemoryRepository<Employee>();
        var notificationService = new NotificationService();
        notificationService.OnEmployeeAdded += (employeeName) => Console.WriteLine($"[Notify] Nhân viên mới: {employeeName}");

        var employeeManager = new EmployeeManager(notificationService, employeeRepository);
        var employeeReportService = new EmployeeReportService(employeeRepository);

        employeeManager.AddFullTimeEmployee("Nguyen Van A", "a@company.com", new DateTime(2021, 3, 15), 2500m, 300m);
        employeeManager.AddPartTimeEmployee("Tran Thi B", "b@company.com", new DateTime(2023, 7, 1), 20m, 80m);
        employeeManager.AddInternEmployee("Le Van C", "c@company.com", new DateTime(2021, 11, 10), 1200m);
        employeeManager.AddFullTimeEmployee("Pham Thi D", "d@company.com", new DateTime(2024, 2, 20), 1400m, 200m);
        employeeManager.AddPartTimeEmployee("Hoang Van E", "e@company.com", new DateTime(2020, 9, 5), 25m, 70m);

        Console.WriteLine();
        Console.WriteLine("=== Nhân viên có lương tháng > 1500 ===");
        var highSalaryEmployees = employeeManager.FindEmployeesByCustomCondition(employee => employee.CalculateMonthlySalary() > 1500m);
        foreach (var employee in highSalaryEmployees)
        {
            Console.WriteLine(employee);
        }

        Console.WriteLine();
        Console.WriteLine("=== Nhân viên vào làm trước năm 2022 ===");
        var joinedBefore2022Employees = employeeManager.FindEmployeesByCustomCondition(employee => employee.HireDate.Year < 2022);
        foreach (var employee in joinedBefore2022Employees)
        {
            Console.WriteLine(employee);
        }

        Console.WriteLine();
        Console.WriteLine("=== CountEmployeesByType ===");
        foreach (var item in employeeReportService.CountEmployeesByType())
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine();
        Console.WriteLine("=== TotalSalaryByType ===");
        foreach (var item in employeeReportService.TotalSalaryByType())
        {
            Console.WriteLine($"{item.Key}: {item.Value:C}");
        }

        Console.WriteLine();
        Console.WriteLine("=== GetTopNHighestPaid(3) ===");
        foreach (var employee in employeeReportService.GetTopNHighestPaid(3))
        {
            Console.WriteLine(employee);
        }

        Console.WriteLine();
        Console.WriteLine("=== GroupByHireYear ===");
        foreach (var item in employeeReportService.GroupByHireYear())
        {
            Console.WriteLine($"{item.Key}:");
            foreach (var employee in item.Value)
            {
                Console.WriteLine($"  {employee}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("=== GetAverageSalary ===");
        Console.WriteLine(employeeReportService.GetAverageSalary().ToString("C"));

        Console.WriteLine();
        Console.WriteLine("=== GetHighestPaidEmployee ===");
        Console.WriteLine(employeeReportService.GetHighestPaidEmployee());

        Console.WriteLine();
        Console.WriteLine("=== GenerateSummaryReport ===");
        Console.WriteLine(employeeReportService.GenerateSummaryReport());
    }
}

