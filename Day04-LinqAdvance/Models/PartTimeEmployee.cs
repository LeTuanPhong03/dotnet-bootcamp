namespace Day04.Models;
public class PartTimeEmployee : Employee
{
    private decimal hourlyRate;
    public decimal HourlyRate
    {
        get => hourlyRate;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hourly rate cannot be negative.", nameof(value));
            }
            hourlyRate = value;
        }
    }
    private decimal hoursWorked;
    public decimal HoursWorked
    {
        get => hoursWorked;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hours worked cannot be negative.", nameof(value));
            }
            else if(value > 300)
            {
                throw new ArgumentException("Hours worked cannot exceed 300 hours per month.", nameof(value));
            }
            hoursWorked = value;
        }
    }
    public PartTimeEmployee(string fullName, string email, DateTime hireDate, decimal hourlyRate, decimal hoursWorked)
        : base(fullName, email, hireDate)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateMonthlySalary()
    {
        return HourlyRate * HoursWorked;
    }

    public override string EmployeeType => "Part-Time";
}