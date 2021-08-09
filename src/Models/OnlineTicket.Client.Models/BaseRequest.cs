using OnlineTicket.Models.Clients.OBilet.Common;
using System;
using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet
{
    public class BaseRequest
    {
        [JsonPropertyName("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class BaseRequest<T> : BaseRequest
    {
        public T Data { get; set; }
    }
}