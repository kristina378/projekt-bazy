using CsvHelper.Configuration.Attributes;

namespace BenchmarkApp.Models;
public class Location
{
    [Name("ID_Lokalizacji")]
    public int Id { get; set; } 

    [Name("Miasto")]
    public string City { get; set; } = null!;
    
    [Ignore]
    public List<Device> Devices { get; set; } = new List<Device>();
}
