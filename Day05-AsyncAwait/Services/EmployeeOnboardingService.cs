using Day05.Interfaces;
namespace Day05.Services;

public class EmployeeOnboardingService
{
    private readonly IExternalHrService externalHrService;
    public EmployeeOnboardingService(IExternalHrService externalHrService)
    {
        this.externalHrService = externalHrService;
    }
    public async Task<string> OnboardEmployeeAsync(string fullName, string email, string employeeType)
    {
        var isEmailValid = await externalHrService.VerifyEmailAsync(email);
        if (!isEmailValid)
        {
            return "Invalid email address.";
        }

        var salaryBenchmark = await externalHrService.FetchMarketSalaryBenchmarkAsync(employeeType);

        return "Email verified. Market salary benchmark for " + employeeType + " is " + salaryBenchmark;
    }

    public async Task<IReadOnlyList<string>> OnboardMultipleEmployeesAsync(IReadOnlyList<(string fullName, string email, string employeeType)> newHires)
    {
        return await Task.WhenAll(newHires.Select(async hire => await OnboardEmployeeAsync(hire.fullName, hire.email, hire.employeeType)));
    }
}