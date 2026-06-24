namespace BenchmarkApp.Models;
public class Location
{
    public int Id { get; set; } 
    public string City { get; set; } = null!;
    
    public List<Device> Devices { get; set; } = new List<Device>();
}
