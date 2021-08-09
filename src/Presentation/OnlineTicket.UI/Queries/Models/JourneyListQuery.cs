using MediatR;
using OnlineTicket.Models.Clients.OBilet;
using OnlineTicket.Models.Clients.OBilet.RequestData;
using OnlineTicket.UI.Models.ViewModels;
using System;

namespace OnlineTicket.UI.Queries.Models
{
    public class JourneyListQuery : BaseRequest<BusJourneysRequestData>, IRequest<JourneyListViewModel>
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime Date { get; set; }
    }
}