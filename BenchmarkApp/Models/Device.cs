namespace BenchmarkApp.Models;
public class Device
{
    public int Id { get; set; }
    public int? ParentDeviceId { get; set; }
    public Device? ParentDevice { get; set; }

    public string DeviceType { get; set; } = null!;
    public string IpAddress { get; set; } = null!;
    
    // Klucz obcy (odpowiednik kolumny INT w SQL)
    public int LocationId { get; set; }
    
    // Właściwość nawigacyjna (nie tworzy kolumny, służy logice ORM w C#)
    public Location Location { get; set; } = null!;
}
