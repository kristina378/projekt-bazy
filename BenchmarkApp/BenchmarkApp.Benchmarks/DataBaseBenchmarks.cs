using BenchmarkDotNet.Attributes;
using BenchmarkApp; // <-- To pozwala widzieć BenchmarkDbContext

namespace BenchmarkApp.Benchmarks;

[MemoryDiagnoser]
public class DatabaseBenchmark
{
    private BenchmarkDbContext _context = null!;

    [GlobalSetup]
    public void Setup()
    {
        _context = new BenchmarkDbContext();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }

    [Benchmark]
    public int CountAllLogs()
    {
        return _context.Logs.Count();
    }
}