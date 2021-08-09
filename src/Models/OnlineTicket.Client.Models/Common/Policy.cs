using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.Common
{
    public class Policy
    {
        [JsonPropertyName("max-seats")]
        public object MaxSeats { get; set; }

        [JsonPropertyName("max-single")]
        public object MaxSingle { get; set; }

        [JsonPropertyName("max-single-males")]
        public int? MaxSingleMales { get; set; }

        [JsonPropertyName("max-single-females")]
        public int? MaxSingleFemales { get; set; }

        [JsonPropertyName("mixed-genders")]
        public bool MixedGenders { get; set; }

        [JsonPropertyName("gov-id")]
        public bool GovId { get; set; }
        public bool Lht { get; set; }
    }
}