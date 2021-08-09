using System;
using System.Collections.Generic;

namespace OnlineTicket.UI.Models.ViewModels
{
    public class JourneyListViewModel
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string Date { get; set; }
        public List<JourneyListItem> Journey { get; set; }
    }

    public class JourneyListItem
    {
        public string PartnerName { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }

        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Currency { get; set; }
        public string Duration { get; set; }
        public decimal OriginalPrice { get; set; }
        public int StopsCount { get; set; }
    }
}