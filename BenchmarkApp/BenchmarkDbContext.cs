using Microsoft.EntityFrameworkCore;
using BenchmarkApp.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BenchmarkApp;

public class BenchmarkDbContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Edge> Edges { get; set; }
    public DbSet<Log> Logs { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        
        IConfigurationRoot root = builder.Build();

        
        string connectionString = root.GetConnectionString("PostgresConnection") 
            ?? throw new InvalidOperationException("Nie znaleziono ciągu połączeniowego 'PostgresConnection' w pliku konfiguracyjnym.");

        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tłumaczymy EF Core relacje dla krawędzi, aby uniknąć pętli usuwania
        modelBuilder.Entity<Edge>()
            .HasOne(e => e.Source)
            .WithMany()
            .HasForeignKey(e => e.SourceId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Edge>()
            .HasOne(e => e.Target)
            .WithMany()
            .HasForeignKey(e => e.TargetId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Opcjonalnie powiązanie dla drzewa urządzeń
        modelBuilder.Entity<Device>()
            .HasOne(d => d.ParentDevice)
            .WithMany()
            .HasForeignKey(d => d.ParentDeviceId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Location>()
            .Property(l => l.Id)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<Device>()
            .Property(l => l.Id)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<Edge>()
            .Property(l => l.Id)
            .ValueGeneratedNever();
        
        modelBuilder.Entity<Log>()
            .Property(l => l.Id)
            .ValueGeneratedNever();
    }
}