using System;
using Day06.Models;
using Day06.Services;
using Day06.Repositories;
using Day06.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Day06;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Day06 onboarding tests
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<IRepository<Employee>, InMemoryRepository<Employee>>();
        services.AddSingleton<NotificationService>();
        services.AddTransient<EmployeeReportService>();
        services.AddTransient<EmployeeManager>();
        services.AddTransient<IExternalHrService, MockExternalHrService>();
        services.AddTransient<EmployeeOnboardingService>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        EmployeeManager employeeManager = serviceProvider.GetRequiredService<EmployeeManager>();
        var employeeOnboardingService = serviceProvider.GetRequiredService<EmployeeOnboardingService>();
        var employeeReportService = serviceProvider.GetRequiredService<EmployeeReportService>();
        var externalHrService = serviceProvider.GetRequiredService<IExternalHrService>();
        var employeeRepository = serviceProvider.GetRequiredService<IRepository<Employee>>();
        Console.WriteLine($"Employee count 1 Repository Hash Code: {employeeRepository.GetHashCode()} And Employee count: {employeeRepository.Count}");
        employeeRepository.Add(new FullTimeEmployee(
            fullName : "John Doe",
            email : "john.doe@company.com",
            hireDate : new DateTime(2023, 1, 15),
            baseSalary : 80000,
            bonus : 10000
        ));
        var repo2 = serviceProvider.GetRequiredService<IRepository<Employee>>();
        Console.WriteLine($"Employee count 2 Repository Hash Code: {repo2.GetHashCode()} And Employee count: {repo2.Count}");
    }
}

