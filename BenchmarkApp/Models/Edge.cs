namespace BenchmarkApp.Models;

public class Edge
{
    public int Id { get; init; }
    public int SourceId { get; init; }
    public int TargetId { get; init; }

    public Device Source { get; set; } = null!;
    public Device Target { get; set; } = null!;

    public int Delay { get; set; }
}
