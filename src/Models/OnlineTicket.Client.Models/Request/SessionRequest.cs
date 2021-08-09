using OnlineTicket.Models.Clients.OBilet.Common;

namespace OnlineTicket.Models.Clients.OBilet.Request
{
    public class SessionRequest
    {
        public int Type { get; set; }
        public Connection Connection { get; set; }
        public Browser Browser { get; set; }
    }
}