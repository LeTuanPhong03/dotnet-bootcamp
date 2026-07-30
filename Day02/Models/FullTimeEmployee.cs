namespace EmployeeManagementApp.Models;
public class FullTimeEmployee : Employee
{
    private decimal baseSalary;
    public decimal BaseSalary
    {
        get => baseSalary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Base salary cannot be negative.", nameof(value));
            }
            baseSalary = value;
        }
    }
    private decimal bonus;
    public decimal Bonus
    {
        get => bonus;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Bonus cannot be negative.", nameof(value));
            }
            bonus = value;
        }
    }
    public FullTimeEmployee(string fullName, string email, DateTime hireDate, decimal baseSalary, decimal bonus)
        : base(fullName, email, hireDate)
    {
        BaseSalary = baseSalary;
        Bonus = bonus;
    }
    public override decimal CalculateMonthlySalary()
    {
        return BaseSalary + Bonus;
    }

    public override string EmployeeType => "Full-Time";
}