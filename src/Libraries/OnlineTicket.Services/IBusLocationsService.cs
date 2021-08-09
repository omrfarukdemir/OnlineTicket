using OnlineTicket.Models.Clients.OBilet.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTicket.Services
{
    public interface IBusLocationsService
    {
        ValueTask<List<BusLocationsResponse>> GetBusLocationsAsync(Func<BusLocationsResponse, bool> filter);

        ValueTask<BusLocationsResponse> GetBusLocationAsync(int id);

        ValueTask<List<BusLocationsResponse>> GetTopBusLocationsAsync(int count = 7);
    }
}