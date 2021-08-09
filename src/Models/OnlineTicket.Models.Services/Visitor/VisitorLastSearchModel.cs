using System;

namespace OnlineTicket.Models.Services.Visitor
{
    public class VisitorLastSearchModel
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime Date { get; set; }
    }
}