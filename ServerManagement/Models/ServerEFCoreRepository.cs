using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;

namespace ServerManagement.Models;

public class ServerEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory) : IServerEFCoreRepository
{
    private readonly IDbContextFactory<ServerManagementContext> contextFactory = contextFactory;

    public void Add(Server server)
    {
        using var db = contextFactory.CreateDbContext();
        db.Servers.Add(server);
        db.SaveChanges();
    }

    public List<Server> FindAll()
    {
        using var db = contextFactory.CreateDbContext();
        return [.. db.Servers];
    }

    public Server FindById(int serverId)
    {
        using var db = contextFactory.CreateDbContext();
        return db.Servers.Find(serverId) ?? new Server();
    }

    public List<Server> FindByName(string serverName)
    {
        using var db = contextFactory.CreateDbContext();
        return [.. db.Servers.Where(s => s.Name.ToLower().Contains(serverName.ToLower()))];
    }

    public List<Server> FindByCity(string cityName)
    {
        using var db = contextFactory.CreateDbContext();
        return [.. db.Servers.Where(s => s.City.ToLower() == cityName.ToLower())];
    }

    public void Update(int serverId, Server server)
    {
        ArgumentNullException.ThrowIfNull(server);
        if (serverId != server.Id) return;

        using var db = contextFactory.CreateDbContext();
        var serverToUpdate = db.Servers.Find(serverId);

        if (serverToUpdate is null) return;

        serverToUpdate.IsOnline = server.IsOnline;
        serverToUpdate.Name = server.Name;
        serverToUpdate.City = server.City;

        db.SaveChanges();
    }

    public void Delete(int serverId)
    {
        using var db = contextFactory.CreateDbContext();
        var server = db.Servers.Find(serverId);
        if (server is null) return;

        db.Servers.Remove(server);
        db.SaveChanges();
    }
}
