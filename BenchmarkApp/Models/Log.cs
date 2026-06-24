namespace BenchmarkApp.Models;

public class Log
{
    public int Id { get; init; }
    public int DeviceId { get; init; }
    public Device Device { get; set; } = null!;

    public DateTime EventDate { get; set; }
    public int Ping { get; set; }

    public string Status { get; set;} = null!;
}
