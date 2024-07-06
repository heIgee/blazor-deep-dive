using Microsoft.EntityFrameworkCore;
using ServerManagement.Models;

namespace ServerManagement.Data;

public class ServerManagementContext(DbContextOptions<ServerManagementContext> options) : DbContext(options)
{
    public DbSet<Server> Servers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Server>().HasData([
            new Server(1,"Nebula", "Tokyo"),
            new Server(2, "QuantumCore", "Berlin"),
            new Server(3, "Phoenix", "London"),
            new Server(4, "TitanX", "Sydney"),
            new Server(5, "CyberWave", "Tokyo"),
            new Server(6, "Hyperion", "London"),
            new Server(7, "Aether", "Paris"),
            new Server(8, "Vortex", "Singapore"),
            new Server(9, "Pulsar", "Shanghai"),
            new Server(10, "Zenith", "Singapore"),
            new Server(11, "Stratos", "Shanghai"),
            new Server(12, "Aurora", "Berlin"),
            new Server(13, "Nimbus", "Tokyo")
        ]);
    }
}
