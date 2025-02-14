using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMC_Launcher.Benchmarks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using Microsoft.VisualStudio.TestPlatform.TestHost;

[assembly: Config(typeof(AssemblyInfo))]

namespace BadMC_Launcher.Benchmarks;

internal class AssemblyInfo : ManualConfig {
    public AssemblyInfo() {
        AddJob(Job.Dry);
        AddLogger(ConsoleLogger.Default);
        AddValidator(JitOptimizationsValidator.DontFailOnError);
    }

    public static void Main(string[] args) {
        var summary = BenchmarkRunner.Run(typeof(UnitTest1).Assembly);
        Console.WriteLine(summary);
        Console.Write("Test complete, press any key to continue ......");
        Console.ReadKey();
    }
}
