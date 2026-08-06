using Day06.Interfaces;
namespace Day06.Models;

public abstract class Employee : ISalaryCalculator
{
    private static int nextId = 1;
    public int Id { get; }

    private string fullName = string.Empty;
    public string FullName
    {
        get => fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Full name cannot be empty.", nameof(value));
            }

            fullName = value;
        }
    }

    private string email = string.Empty;
    public string Email
    {
        get => email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email is not valid.", nameof(value));
            }

            string emailValue = value;
            int atIndex = emailValue.IndexOf('@');
            int dotIndex = atIndex >= 0 ? emailValue.IndexOf('.', atIndex + 1) : -1;

            if (atIndex <= 0 || dotIndex <= atIndex + 1 || dotIndex == emailValue.Length - 1)
            {
                throw new ArgumentException("Email is not valid.", nameof(value));
            }

            email = emailValue;
        }
    }

    private DateTime hireDate;
    public DateTime HireDate
    {
        get => hireDate;
        set
        {
        if (value > DateTime.Today)
        {
            throw new ArgumentException("Hire date cannot be in the future.", nameof(value));
        }
        hireDate = value;
        }
    }
    public abstract string EmployeeType { get; }
    public Employee(string fullName, string email, DateTime hireDate)
    {
        Id = nextId++;
        FullName = fullName;
        Email = email;
        HireDate = hireDate;
    }


    public abstract decimal CalculateMonthlySalary();

    public decimal CalculateAnnualSalary()
    {
        return CalculateMonthlySalary() * 12;
    }
    public override string ToString()
    {
        return $"[{Id}] {FullName} - {Email} - Loại: {EmployeeType} - Lương/tháng: {CalculateMonthlySalary():C}/month";
    }
}