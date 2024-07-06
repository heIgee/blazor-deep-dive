
namespace ServerManagement.Models;

public interface IServerEFCoreRepository
{
    void Add(Server server);
    void Delete(int serverId);
    List<Server> FindAll();
    List<Server> FindByCity(string cityName);
    Server FindById(int serverId);
    List<Server> FindByName(string serverName);
    void Update(int serverId, Server server);
}