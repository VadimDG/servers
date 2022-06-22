using System.Linq;
using TestWebApi.Data;
using TestWebApi.Dto;

namespace TestWebApi.Services
{
    public class ServersService : IServersService
    {
        private readonly ServersDbContext _serversDbContext;

        public ServersService(ServersDbContext context)
        {
            _serversDbContext = context;
        }

        public async Task CreateServerAsync()
        {
            await _serversDbContext.Servers.AddAsync(new Data.Models.Server { CreatedDateTime = DateTime.Now });
            await _serversDbContext.SaveChangesAsync();
        }

        public async Task DeleteServerAsync(List<int> serversIds)
        {
            foreach (var id in serversIds)
            {
                var server = await _serversDbContext.Servers.FindAsync(id);
                server.RemoveDateTime = DateTime.Now;
                _serversDbContext.Servers.Update(server);
            }
            
            await _serversDbContext.SaveChangesAsync();
        }

        public ServersDto GetServers()
        {
            var res = _serversDbContext.Servers.Select(x => new ServersInfo
            {
                Id = x.Id,
                CreatedDateTime = x.CreatedDateTime,
                RemoveDateTime = x.RemoveDateTime
            }).ToList();

            var now = DateTime.Now;
            if (res.Count == 0)
            {
                return new ServersDto
                {
                    ServersInfo = res,
                    TotalUsageTime = null
                };
            }
            var diff = (now - res.Max(x => x.CreatedDateTime));    

            return new ServersDto
            {
                ServersInfo = res,
                TotalUsageTime = new DateTime(now.Year, now.Month, now.Day, diff.Hours, diff.Minutes, diff.Seconds)
            };
        }
    }
}
