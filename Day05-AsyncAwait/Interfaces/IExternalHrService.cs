namespace Day05.Interfaces;

public interface IExternalHrService
{
    Task<bool> VerifyEmailAsync(string email);
    Task<decimal> FetchMarketSalaryBenchmarkAsync(string employeeType); 
}