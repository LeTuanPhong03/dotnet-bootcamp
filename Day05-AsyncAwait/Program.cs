using System;
using System.Threading.Tasks;
using Day05.Models;
using Day05.Services;
using Day05.Repositories;
using Day05.Interfaces;
using System.Diagnostics;
using System.Collections.Generic;

namespace Day05;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Day05 onboarding tests
        var onboardingService = new EmployeeOnboardingService(new MockExternalHrService());

        Console.WriteLine();
        Console.WriteLine("=== OnboardEmployeeAsync single tests ===");
        var sw = Stopwatch.StartNew();
        var validResult = await onboardingService.OnboardEmployeeAsync("Nguyen Van X", "valid@example.com", "Full-Time");
        sw.Stop();
        Console.WriteLine($"Result (valid): {validResult} (took {sw.Elapsed.TotalMilliseconds:F0} ms)");

        sw.Restart();
        var invalidResult = await onboardingService.OnboardEmployeeAsync("Nguyen Van Y", "invalid-email", "Intern");
        sw.Stop();
        Console.WriteLine($"Result (invalid): {invalidResult} (took {sw.Elapsed.TotalMilliseconds:F0} ms)");

        Console.WriteLine();
        Console.WriteLine("=== OnboardMultipleEmployeesAsync parallel vs sequential test ===");

        var hires = new List<(string fullName, string email, string employeeType)>
        {
            ("A Nguyen", "a@company.com", "Full-Time"),
            ("B Tran", "b@company.com", "Part-Time"),
            ("C Le", "c@company.com", "Intern"),
            ("D Pham", "d@company.com", "Full-Time")
        };

        var swParallel = Stopwatch.StartNew();
        var parallelResults = await onboardingService.OnboardMultipleEmployeesAsync(hires);
        swParallel.Stop();
        Console.WriteLine($"Parallel total time: {swParallel.Elapsed.TotalMilliseconds:F0} ms");
        for (int i = 0; i < parallelResults.Count; i++)
        {
            Console.WriteLine($"  {hires[i].fullName}: {parallelResults[i]}");
        }

        var swSeq = Stopwatch.StartNew();
        var seqResults = new List<string>();
        foreach (var h in hires)
        {
            seqResults.Add(await onboardingService.OnboardEmployeeAsync(h.fullName, h.email, h.employeeType));
        }
        swSeq.Stop();
        Console.WriteLine($"Sequential total time: {swSeq.Elapsed.TotalMilliseconds:F0} ms");

        Console.WriteLine();
        if (swParallel.Elapsed < swSeq.Elapsed)
        {
            Console.WriteLine($"Parallel was faster by {(swSeq.Elapsed - swParallel.Elapsed).TotalMilliseconds:F0} ms.");
        }
        else
        {
            Console.WriteLine($"Sequential was faster by {(swParallel.Elapsed - swSeq.Elapsed).TotalMilliseconds:F0} ms.");
        }
    }
}
