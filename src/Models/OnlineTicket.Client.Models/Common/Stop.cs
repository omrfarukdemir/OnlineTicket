using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.Common
{
    public class Stop
    {
        public string Name { get; set; }
        public string Station { get; set; }
        public string Time { get; set; }

        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }
    }
}