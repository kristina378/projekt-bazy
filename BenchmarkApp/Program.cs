using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using BenchmarkApp;
using BenchmarkApp.Models;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Inicjalizacja połączenia z bazą...");
        using var context = new BenchmarkDbContext();

        // Optymalizacja pod kątem masowego wstawiania (Bulk Insert)
        context.ChangeTracker.AutoDetectChangesEnabled = false;

        // Konfiguracja ignorująca brakujące kolumny (właściwości nawigacyjne)
        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        };

        // 1. LOKALIZACJE
        Console.WriteLine("1/4: Odczyt i zapis lokalizacje.csv...");
        using (var reader = new StreamReader("lokalizacje.csv"))
        using (var csv = new CsvReader(reader, csvConfig))
        {
            var locations = csv.GetRecords<Location>().ToList();
            Console.WriteLine($"Wczytano {locations.Count} lokalizacji z pliku. Zapisuję w bazie...");
            context.Locations.AddRange(locations);
            context.SaveChanges();
        }

        // 2. URZĄDZENIA
        Console.WriteLine("2/4: Odczyt i zapis urzadzenia.csv...");
        using (var reader = new StreamReader("urzadzenia.csv"))
        using (var csv = new CsvReader(reader, csvConfig))
        {
            var devices = csv.GetRecords<Device>().ToList();
            Console.WriteLine($"Wczytano {devices.Count} urzadzen z pliku. Zapisuję w bazie...");
            context.Devices.AddRange(devices);
            context.SaveChanges();
        }

        // 3. KRAWĘDZIE
        Console.WriteLine("3/4: Odczyt i zapis krawedzie.csv...");
        using (var reader = new StreamReader("krawedzie.csv"))
        using (var csv = new CsvReader(reader, csvConfig))
        {
            var edges = csv.GetRecords<Edge>().ToList();
            Console.WriteLine($"Wczytano {edges.Count} krawedzi z pliku. Zapisuję w bazie...");
            context.Edges.AddRange(edges);
            context.SaveChanges();
        }

        // 4. LOGI (Największy plik)
        Console.WriteLine("4/4: Odczyt i zapis logi.csv (To zajmie dłuższą chwilę)...");
        using (var reader = new StreamReader("logi.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var logs = csv.GetRecords<Log>().ToList();
            
            // Wymuszenie strefy czasowej UTC dla każdej daty przed zapisem
            logs.ForEach(l => l.EventDate = DateTime.SpecifyKind(l.EventDate, DateTimeKind.Utc));
            
            Console.WriteLine($"Wczytano {logs.Count} logow z pliku. Zapisuję w bazie...");
            context.Logs.AddRange(logs);
            context.SaveChanges();
        }

        Console.WriteLine("Kompletny import środowiska testowego zakończony sukcesem.");
    }
}