
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Services;

namespace EmployeeManagementApp;

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeManager employeeManager = new EmployeeManager();

        employeeManager.AddFullTimeEmployee("John Doe", "john.doe@example.com", new DateTime(2020, 1, 15), 2000, 100);
        employeeManager.AddFullTimeEmployee("Jane Smith", "jane.smith@example.com", new DateTime(2019, 3, 20), 2500, 199);

        employeeManager.AddPartTimeEmployee("Bob Johnson", "bob.johnson@example.com", new DateTime(2021, 7, 10), 1, 120);
        employeeManager.AddPartTimeEmployee("Alice Brown", "alice.brown@example.com", new DateTime(2022, 5, 25), 20, 80);

        employeeManager.AddInternEmployee("Charlie Davis", "charlie.davis@example.com", new DateTime(2023, 9, 12), 500);

        employeeManager.AddPartTimeEmployee("Invalid Worker", "invalid@example.com", new DateTime(2023, 1, 1), 18, 350);


        Console.WriteLine("Valid employees:");
        employeeManager.PrintAllEmployees();

        Console.WriteLine("-------------------");
        Console.WriteLine("After removing employee with Id = 2:");
        employeeManager.RemoveEmployee(2);

        employeeManager.PrintAllEmployees();
    }
}

