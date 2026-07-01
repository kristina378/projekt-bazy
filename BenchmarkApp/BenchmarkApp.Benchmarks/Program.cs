using BenchmarkDotNet.Running;

namespace BenchmarkApp.Benchmarks;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Inicjalizacja środowiska testowego...");
        var summary = BenchmarkRunner.Run<DatabaseBenchmark>();
    }
}
