using Day05.Models;
using Day05.Interfaces;
namespace Day05.Services;
public class EmployeeReportService
{
    private readonly IRepository<Employee> employeeRepository;

    public EmployeeReportService(IRepository<Employee> employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public IReadOnlyDictionary<string,int> CountEmployeesByType()
    {
        return employeeRepository.GetAll().GroupBy(employee => employee.EmployeeType).ToDictionary(group => group.Key, group => group.Count());
    }

    public IReadOnlyDictionary<string, decimal> TotalSalaryByType()
    {
        return employeeRepository.GetAll().GroupBy(employee => employee.EmployeeType).ToDictionary(group => group.Key, group => group.Sum(employee => employee.CalculateMonthlySalary()));
    }

    public IReadOnlyList<Employee> GetTopNHighestPaid(int n)
    {
        return employeeRepository.GetAll().OrderByDescending(employee => employee.CalculateMonthlySalary()).Take(n).ToList();
    }

    public IReadOnlyDictionary<int, IReadOnlyList<Employee>> GroupByHireYear()
    {
        return employeeRepository.GetAll().GroupBy(employee => employee.HireDate.Year).ToDictionary(group => group.Key, group => (IReadOnlyList<Employee>)group.ToList());
    }
    public decimal GetAverageSalary()
    {
        var allEmployees = employeeRepository.GetAll();
        if (allEmployees.Count == 0)
        {
            return 0m;
        }
        return allEmployees.Average(employee => employee.CalculateMonthlySalary());
    }
    public Employee? GetHighestPaidEmployee()
    {
        return employeeRepository.GetAll().OrderByDescending(employee=> employee.CalculateMonthlySalary()).FirstOrDefault();
    }

    public string GenerateSummaryReport()
    {
        var totalEmployees = employeeRepository.GetAll().Count;
        var averageSalary = GetAverageSalary();
        var highestPaidEmployee = GetHighestPaidEmployee();
        var countByType = CountEmployeesByType();

        return $"Total Employees: {totalEmployees}\n" +
               $"Average Salary: {averageSalary:C}\n" +
               $"Highest Paid Employee: {(highestPaidEmployee != null ? highestPaidEmployee.FullName + " - " + highestPaidEmployee.CalculateMonthlySalary().ToString("C") : "N/A")}\n" +
               $"Employee Count by Type:\n" +
               string.Join("\n", countByType.Select(kvp => $"  {kvp.Key}: {kvp.Value}"));
    }
}