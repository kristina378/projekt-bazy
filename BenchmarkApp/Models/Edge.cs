using CsvHelper.Configuration.Attributes;

namespace BenchmarkApp.Models;

public class Edge
{
    [Name("ID_Krawedzi")]
    public int Id { get; init; }
    
    [Name("ID_Zrodla")]
    public int SourceId { get; init; }

    [Name("ID_Celu")]
    public int TargetId { get; init; }

    [Ignore]
    public Device Source { get; set; } = null!;
    [Ignore]
    public Device Target { get; set; } = null!;

    [Name("Opoznienie_ms")]
    public int Delay { get; set; }
}
