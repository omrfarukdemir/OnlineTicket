using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.Common
{
    public class Connection
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }

        public string Port { get; set; }
    }
}