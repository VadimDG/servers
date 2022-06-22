using Newtonsoft.Json;

namespace TestWebApi.Dto
{
    public class ServersDto
    {
        [JsonProperty("totalUsageTime")]
        public DateTime? TotalUsageTime { get; set; }

        [JsonProperty("serversInfo")]
        public List<ServersInfo> ServersInfo { get; set; }
    }

    public class ServersInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("removeDateTime")]
        public DateTime? RemoveDateTime { get; set; }
    }
}
