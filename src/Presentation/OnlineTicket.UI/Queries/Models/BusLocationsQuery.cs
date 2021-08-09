using MediatR;
using OnlineTicket.Models.Clients.OBilet;
using OnlineTicket.UI.Models.ViewModels;

namespace OnlineTicket.UI.Queries.Models
{
    public class BusLocationsQuery : BaseRequest, IRequest<BusLocationViewModel>
    {
        public string Query { get; set; }
    }
}