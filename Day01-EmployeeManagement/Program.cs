
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Services;

namespace EmployeeManagementApp;

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeManager employeeManager = new EmployeeManager();

        employeeManager.AddEmployee("John Doe", "john.doe@example.com", 50000, new DateTime(2020, 1, 15));
        employeeManager.AddEmployee("Jane Smith", "jane.smith@example.com", 55000, new DateTime(2019, 3, 20));
        employeeManager.AddEmployee("Bob Johnson", "bob.johnson@example.com", 48000, new DateTime(2021, 7, 10));
        employeeManager.AddEmployee("Alice Brown", "alice.brownexample.com", 52000, new DateTime(2022, 5, 25));
        employeeManager.AddEmployee("Charlie Davis", "charlie.davis@example.com", -51000, new DateTime(2023, 9, 12));
        employeeManager.AddEmployee("Future Hire", "future.hire@example.com", 60000, DateTime.Now.AddDays(5));

        Console.WriteLine("Valid employees:");
        employeeManager.PrintAllEmployees();

        Console.WriteLine("-------------------");
        Console.WriteLine("After removing employee with Id = 2:");
        employeeManager.RemoveEmployee(2);

        employeeManager.PrintAllEmployees();
    }
}

