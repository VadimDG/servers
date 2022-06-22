using Microsoft.AspNetCore.Mvc;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Route("api/servers")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IServersService _serversService;

        public ServersController(IServersService serversService)
        {
            _serversService = serversService;
        }

        [HttpGet]
        [Route("GetServers")]
        public IActionResult GetServers()
        {
            var res = _serversService.GetServers();
            return new JsonResult(res);
        }

        [HttpGet]
        [Route("Remove/{serversIds}")]
        public async Task<IActionResult> Remove(string serversIds)
        {
            if (serversIds == null) 
            {
                return new OkResult();
            }
            var ids = serversIds.Split(',').Select(x => Convert.ToInt32(x)).ToList();
            await _serversService.DeleteServerAsync(ids);
            return new OkResult();
        }

        [HttpGet]
        [Route("CreateServer")]
        public async Task<IActionResult> CreateServer()
        {
            await _serversService.CreateServerAsync();
            return new OkResult();
        }
    }
}
