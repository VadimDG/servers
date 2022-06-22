using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public interface IServersService
    {
        ServersDto GetServers();
        Task CreateServerAsync();
        Task DeleteServerAsync(List<int> serversIds);
    }
}
