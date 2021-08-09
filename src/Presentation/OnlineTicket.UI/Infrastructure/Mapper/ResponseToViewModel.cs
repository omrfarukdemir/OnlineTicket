using AutoMapper;
using OnlineTicket.Models.Clients.OBilet.Response;
using OnlineTicket.UI.Models.ViewModels;

namespace OnlineTicket.UI.Infrastructure.Mapper
{
    public class ResponseToViewModel : Profile
    {
        public ResponseToViewModel()
        {
            CreateMap<BusLocationsResponse, BusLocationListItem>()
                .ForMember(x => x.Data, x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Value, x => x.MapFrom(m => m.Name));

            CreateMap<BusJourneysResponse, JourneyListItem>()

                .ForMember(x => x.Arrival, x => x.MapFrom(y => y.Journey.Arrival))
                .ForMember(x => x.Departure, x => x.MapFrom(y => y.Journey.Departure))
                .ForMember(x => x.Currency, x => x.MapFrom(y => y.Journey.Currency))
                .ForMember(x => x.Destination, x => x.MapFrom(y => y.Journey.Destination))
                .ForMember(x => x.Duration, x => x.MapFrom(y => y.Journey.Duration))
                .ForMember(x => x.Origin, x => x.MapFrom(y => y.Journey.Origin))
                .ForMember(x => x.OriginalPrice, x => x.MapFrom(y => y.Journey.OriginalPrice))
                .ForMember(x => x.StopsCount, x => x.MapFrom(y => y.Journey.Stops.Count));
        }
    }
}