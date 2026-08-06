using Day05.Models;
using Day05.Interfaces;
namespace Day05.Services;

public class EmployeeManager
{
    private readonly NotificationService notificationService;
    private readonly IRepository<Employee> employeeRepository;

    public EmployeeManager(NotificationService notificationService, IRepository<Employee> employeeRepository)
    {
        this.notificationService = notificationService;
        this.employeeRepository = employeeRepository;
    }

    public IEnumerable<Employee> FindEmployeesByCustomCondition(Func<Employee, bool> condition)
    {
        return employeeRepository.GetAll().Where(condition);
    }

    public void AddFullTimeEmployee(string fullName, string email, DateTime hireDate, decimal baseSalary, decimal bonus){
        try
        {
            var fullTimeEmployee = new FullTimeEmployee(fullName, email, hireDate, baseSalary, bonus);
            employeeRepository.Add(fullTimeEmployee);
            notificationService.Notify(fullTimeEmployee.FullName);
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
            employeeRepository.Add(partTimeEmployee);
            notificationService.Notify(partTimeEmployee.FullName);
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
            employeeRepository.Add(internEmployee);
            notificationService.Notify(internEmployee.FullName);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid employee rejected: {ex.Message}");
        }
    }

    public decimal GetTotalMonthlySalaryCost() => employeeRepository.GetAll().Sum(employee => employee.CalculateMonthlySalary());
    
    

    public void RemoveEmployee(int id)
    {
        var removed = employeeRepository.Remove(e => e.Id == id);
        if (removed)
        {
            Console.WriteLine($"Employee with Id {id} was removed.");
        }
    }

    public void PrintAllEmployees()
    {
        foreach (var employee in employeeRepository.GetAll())
        {
            Console.WriteLine(employee);
        }
    }
}