namespace Day07.Models;

public class Intern : Employee
{
    private decimal monthlyAllowance;
    public decimal MonthlyAllowance
    {
        get => monthlyAllowance;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Monthly allowance cannot be negative.", nameof(value));
            }
            monthlyAllowance = value;
        }
    }

    public Intern(string fullName, string email, DateTime hireDate, decimal monthlyAllowance)
        : base(fullName, email, hireDate)
    {
        MonthlyAllowance = monthlyAllowance;
    }

    public override decimal CalculateMonthlySalary()
    {
        return MonthlyAllowance;
    }

    public override string EmployeeType => "Intern";
}