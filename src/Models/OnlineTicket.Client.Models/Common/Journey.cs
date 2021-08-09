using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.Common
{
    public class Journey
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public List<Stop> Stops { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public string Currency { get; set; }
        public string Duration { get; set; }

        [JsonPropertyName("original-price")]
        public double? OriginalPrice { get; set; }

        [JsonPropertyName("internet-price")]
        public double? InternetPrice { get; set; }

        [JsonPropertyName("provider-internet-price")]
        public object ProviderInternetPrice { get; set; }

        public object Booking { get; set; }

        [JsonPropertyName("bus-name")]
        public string BusName { get; set; }

        public Policy Policy { get; set; }
        public List<string> Features { get; set; }
        public object Description { get; set; }
        public object Available { get; set; }
    }
}