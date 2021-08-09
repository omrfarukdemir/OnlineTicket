using System.Text.Json.Serialization;

namespace OnlineTicket.Models.Clients.OBilet
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public string Status { get; set; }
        public object Message { get; set; }

        [JsonPropertyName("user-message")]
        public object UserMessage { get; set; }

        [JsonPropertyName("api-request-id")]
        public object ApiRequestId { get; set; }

        public object Controller { get; set; }

        [JsonPropertyName("client-request-id")]
        public object ClientRequestId { get; set; }
    }
}