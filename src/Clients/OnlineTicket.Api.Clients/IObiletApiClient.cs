using OnlineTicket.Models.Clients.OBilet;
using OnlineTicket.Models.Clients.OBilet.Request;
using OnlineTicket.Models.Clients.OBilet.Response;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTicket.Clients.OBilet
{
    public interface IObiletApiClient
    {
        [Post("/client/getsession")]
        Task<IApiResponse<BaseResponse<SessionResponse>>> GetSession([Body] SessionRequest model);

        [Post("/location/getbuslocations")]
        Task<IApiResponse<BaseResponse<List<BusLocationsResponse>>>> GetBusLocations([Body] BusLocationsRequest model);

        [Post("/journey/getbusjourneys")]
        Task<IApiResponse<BaseResponse<List<BusJourneysResponse>>>> GetBusJourneys([Body] BusJourneysRequest model);
    }
}