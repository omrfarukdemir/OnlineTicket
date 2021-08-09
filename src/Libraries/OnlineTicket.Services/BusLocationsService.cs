using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using OnlineTicket.Clients.OBilet;
using OnlineTicket.Infrastructure;
using OnlineTicket.Models.Clients.OBilet;
using OnlineTicket.Models.Clients.OBilet.Common;
using OnlineTicket.Models.Clients.OBilet.Request;
using OnlineTicket.Models.Clients.OBilet.Response;

namespace OnlineTicket.Services
{
    public class BusLocationsService : IBusLocationsService
    {
        private readonly IDeviceSessionService _deviceSessionService;
        private readonly IMemoryCache _memoryCache;
        private readonly IObiletApiClient _apiClient;

        public BusLocationsService(
            IDeviceSessionService deviceSessionService,
            IMemoryCache memoryCache,
            IObiletApiClient apiClient)
        {
            _deviceSessionService = deviceSessionService;
            _memoryCache = memoryCache;
            _apiClient = apiClient;
        }

        public async ValueTask<List<BusLocationsResponse>> GetBusLocationsAsync(Func<BusLocationsResponse, bool> predicate)
        {
            var busLocations = await GetFromCacheBusLocationsAsync();

            return busLocations.Where(predicate).ToList();
        }

        public async ValueTask<BusLocationsResponse> GetBusLocationAsync(int id)
        {
            return (await GetBusLocationsAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async ValueTask<List<BusLocationsResponse>> GetTopBusLocationsAsync(int count = 7)
        {
            var busLocations = await GetFromCacheBusLocationsAsync();

            return busLocations.Take(count).ToList();
        }

        private async ValueTask<List<BusLocationsResponse>> GetFromCacheBusLocationsAsync()
        {
            var result = _memoryCache.Get<List<BusLocationsResponse>>(CacheKeys.BusLocations);

            if (result is not null) return result;

            var session = await _deviceSessionService.GetDeviceSessionAsync();

            var response = await _apiClient.GetBusLocations(new BusLocationsRequest()
            {
                DeviceSession = new DeviceSession()
                {
                    DeviceId = session.DeviceId,
                    SessionId = session.SessionId
                },
                Date = DateTime.Now,
                Language = "tr-TR",
            });

            if (response?.Content?.Status != ResponseStatus.Success)
            {
                throw new Exception(response?.Content?.UserMessage.ToString());
            }

            result = response.Content.Data;

            _memoryCache.Set(CacheKeys.BusLocations, result, TimeSpan.FromDays(30));

            return result;
        }
    }
}