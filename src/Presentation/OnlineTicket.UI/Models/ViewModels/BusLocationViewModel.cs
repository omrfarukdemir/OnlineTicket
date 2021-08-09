using System.Collections.Generic;

namespace OnlineTicket.UI.Models.ViewModels
{
    public class BusLocationViewModel
    {
        public List<BusLocationListItem> Suggestions { get; set; }
    }

    public class BusLocationListItem
    {
        public int Data { get; set; }
        public string Value { get; set; }
    }
}