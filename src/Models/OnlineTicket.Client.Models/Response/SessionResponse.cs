using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.Response
{
    public class SessionResponse
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }

        public object Affiliate { get; set; }

        [JsonPropertyName("device-type")]
        public int DeviceType { get; set; }

        public object Device { get; set; }
    }
}