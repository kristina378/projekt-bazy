using CsvHelper.Configuration.Attributes;

namespace BenchmarkApp.Models;

public class Log
{
    [Name("ID_Logu")]
    public int Id { get; init; }

    [Name("ID_Urzadzenia")]
    public int DeviceId { get; init; }
    public Device Device { get; set; } = null!;

    [Name("Data")]
    public DateTime EventDate { get; set; }

    [Name("Ping")]
    public int Ping { get; set; }

    [Name("Status")]
    public string Status { get; set;} = null!;
}
