using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Services;

public class EmployeeManager
{
    private readonly List<Employee> employees = new();

    public void AddEmployee(string fullName, string email, decimal baseSalary, DateTime hireDate)
    {
        try
        {
            Employee employee = new Employee(fullName, email, baseSalary, hireDate);
            employees.Add(employee);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Failed to add employee '{fullName}': {ex.Message}");
        }
    }

    public IReadOnlyList<Employee> GetAllEmployees()
    {
        return employees.AsReadOnly();
    }

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