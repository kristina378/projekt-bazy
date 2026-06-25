using CsvHelper;
using System.Globalization;
using BenchmarkApp;
using BenchmarkApp.Models;
public class Program
{
    static void Main()
    {
        Console.WriteLine("Inicjalizacja połączenia z bazą...");
        using var context = new BenchmarkDbContext();

        Console.WriteLine("Rozpoczynam odczyt pliku lokalizacje.csv...");
        using var reader = new StreamReader("lokalizacje.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        // Mapowanie z pliku bezpośrednio na obiekty bazy danych
        var locations = csv.GetRecords<Location>().ToList();

        Console.WriteLine($"Wczytano {locations.Count} lokalizacji z pliku. Zapisuję w bazie...");

        // Dodanie rekordów do kontekstu EF Core i zatwierdzenie transakcji
        context.Locations.AddRange(locations);
        context.SaveChanges();

        Console.WriteLine("Zapis zakończony sukcesem.");
    }
}