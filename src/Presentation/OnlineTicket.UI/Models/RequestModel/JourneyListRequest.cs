using System;

namespace OnlineTicket.UI.Models.RequestModel
{
    public class JourneyListRequest
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime Date { get; set; }
    }
}