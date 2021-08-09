using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet.Common
{
    public class Feature
    {
        public int Id { get; set; }
        public int? Priority { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }

        [JsonPropertyName("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonPropertyName("back-color")]
        public object BackColor { get; set; }

        [JsonPropertyName("fore-color")]
        public object ForeColor { get; set; }
    }
}