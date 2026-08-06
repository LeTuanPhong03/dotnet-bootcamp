using Day05.Interfaces;
namespace Day05.Services;

public class MockExternalHrService : IExternalHrService
{
    public async Task<bool> VerifyEmailAsync(string email)
    {
        await Task.Delay(500);

        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        var atIndex = email.IndexOf('@');
        if(atIndex < 1 || atIndex == email.Length - 1) return false;
        var dotIndex = email.IndexOf('.', atIndex + 1);
        return dotIndex > atIndex + 1 && dotIndex < email.Length - 1;
    }
    public async Task<decimal> FetchMarketSalaryBenchmarkAsync(string employeeType)
    {
        await Task.Delay(800);

        return employeeType switch
        {
            "Full-Time" => 80000m,
            "Part-Time" => 40000m,
            "Intern" => 20000m,
            _ => 0m // default for any other/unknown employeeType to make the switch exhaustive
        };
    }
}