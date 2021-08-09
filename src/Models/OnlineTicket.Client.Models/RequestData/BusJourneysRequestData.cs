using System;
using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.RequestData
{
    public class BusJourneysRequestData
    {
        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }

        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }

        [JsonPropertyName("departure-date")]
        public string DepartureDate { get; set; }
    }
}