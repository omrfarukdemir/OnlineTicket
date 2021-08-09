using OnlineTicket.Models.Clients.OBilet.Common;
using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.Response
{
    public class BusLocationsResponse
    {
        public int Id { get; set; }

        [JsonPropertyName("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        public string Keywords { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("parent-id")]
        public int ParentId { get; set; }

        public object Rank { get; set; }

        [JsonPropertyName("reference-code")]
        public object ReferenceCode { get; set; }

        public string Type { get; set; }

        [JsonPropertyName("tz-code")]
        public string TzCode { get; set; }

        [JsonPropertyName("weather-code")]
        public object WeatherCode { get; set; }

        public int Zoom { get; set; }
    }
}