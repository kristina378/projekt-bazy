using CsvHelper.Configuration.Attributes;

namespace BenchmarkApp.Models;
public class Device
{
    [Name("ID_Urzadzenia")]
    public int Id { get; set; }

    [Name("ID_Rodzica")]
    public int? ParentDeviceId { get; set; }

    [Ignore]
    public Device? ParentDevice { get; set; }

    [Name("Typ_Urzadzenia")]
    public string DeviceType { get; set; } = null!;

    [Name("Adres_IP")]
    public string IpAddress { get; set; } = null!;
    
    [Name("ID_Lokalizacji")]
    public int LocationId { get; set; }
    
    // Właściwość nawigacyjna (nie tworzy kolumny, służy logice ORM w C#)
    [Ignore]
    public Location Location { get; set; } = null!;
}
