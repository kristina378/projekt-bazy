using BenchmarkApp;
using BenchmarkApp.DataImporter;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Uruchamiam proces zasilania bazy danych...");
        DataImporter.MoveToDB();
    }
}
