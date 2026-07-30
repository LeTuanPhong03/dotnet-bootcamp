using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Services;

public class EmployeeManager
{
    private readonly List<Employee> employees = new();

    public IReadOnlyList<Employee> GetAllEmployees()
    {
        return employees.AsReadOnly();
    }

    public void AddFullTimeEmployee(string fullName, string email, DateTime hireDate, decimal baseSalary, decimal bonus){
        try
        {
            var fullTimeEmployee = new FullTimeEmployee(fullName, email, hireDate, baseSalary, bonus);
            employees.Add(fullTimeEmployee);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid employee rejected: {ex.Message}");
        }
    }

    public void AddPartTimeEmployee(string fullName, string email, DateTime hireDate, decimal hourlyRate, decimal hoursWorked)
    {
        try
        {
            var partTimeEmployee = new PartTimeEmployee(fullName, email, hireDate, hourlyRate, hoursWorked);
            employees.Add(partTimeEmployee);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid employee rejected: {ex.Message}");
        }
    }

    public void AddInternEmployee(string fullName, string email, DateTime hireDate, decimal monthlyAllowance)
    {
        try
        {
            var internEmployee = new Intern(fullName, email, hireDate, monthlyAllowance);
            employees.Add(internEmployee);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid employee rejected: {ex.Message}");
        }
    }

    public decimal GetTotalMonthlySalaryCost() => employees.Sum(employee => employee.CalculateMonthlySalary());
    
    

    public void RemoveEmployee(int id)
    {
        Employee? employee = employees.FirstOrDefault(employee => employee.Id == id);
        if (employee is null)
        {
            Console.WriteLine($"Employee with Id {id} was not found.");
            return;
        }

        employees.Remove(employee);
        Console.WriteLine($"Employee with Id {id} was removed.");
    }

    public void PrintAllEmployees()
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}