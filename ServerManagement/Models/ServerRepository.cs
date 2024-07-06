namespace ServerManagement.Models;

public static class ServerRepository
{
    private static readonly List<Server> servers =
    [
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
    ];

    public static void Add(Server server)
    {
        var maxId = servers.Max(s => s.Id);
        server.Id = maxId + 1;
        servers.Add(server);
    }

    public static List<Server> FindAll() => servers;
    
    public static Server? FindById(int id)
    {
        var server = servers.FirstOrDefault(s => s.Id == id);
        if (server is not null)
        {
            return new Server (server.Id, server.Name, server.City) { IsOnline = server.IsOnline };
        }

        return null;
    }

    public static List<Server> FindByName(string nameFilter)
    {
        return servers.Where(s => 
            s.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public static List<Server> FindByCity(string cityName)
    {
        return servers.Where(s => 
            s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public static void Update(int serverId, Server server)
    {
        if (serverId != server.Id) return;

        var serverToUpdate = servers.FirstOrDefault(s => s.Id == serverId);
        if (serverToUpdate is null)
            return;

        serverToUpdate.IsOnline = server.IsOnline;
        serverToUpdate.Name = server.Name;
        serverToUpdate.City = server.City;
    }

    public static void Delete(int serverId)
    {
        var server = servers.FirstOrDefault(s => s.Id == serverId);
        if (server is not null)
        {
            servers.Remove(server);
        }
    }
}
