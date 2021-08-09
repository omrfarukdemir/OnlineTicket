using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineTicket.Infrastructure;
using OnlineTicket.Infrastructure.Extensions;
using OnlineTicket.Models.Services.Visitor;

namespace OnlineTicket.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBusLocationsService _busLocationsService;

        public VisitorService(IHttpContextAccessor contextAccessor, IBusLocationsService busLocationsService)
        {
            _contextAccessor = contextAccessor;
            _busLocationsService = busLocationsService;
        }

        public async ValueTask<VisitorLastSearchModel> GetVisitorLastSearchAsync()
        {
            var lastSearch = _contextAccessor?.HttpContext?.Session.Get<VisitorLastSearchModel>(SessionKeys.VisitorLastSearch);

            if (lastSearch is not null)
            {
                return lastSearch;
            }

            var topBusLocations = await _busLocationsService.GetTopBusLocationsAsync();

            lastSearch = new VisitorLastSearchModel()
            {
                Date = DateTime.Now,
                OriginId = topBusLocations.FirstOrDefault().Id,
                OriginLocation = topBusLocations.FirstOrDefault().Name,
                DestinationId = topBusLocations.LastOrDefault().Id,
                DestinationLocation = topBusLocations.LastOrDefault().Name
            };

            await SetVisitorLastSearch(lastSearch.OriginId, lastSearch.DestinationId, lastSearch.Date);

            return lastSearch;
        }

        public async ValueTask<VisitorLastSearchModel> SetVisitorLastSearch(int originId, int destinationId, DateTime date)
        {
            var originLocation = await _busLocationsService.GetBusLocationAsync(originId);
            var destinationLocation = await _busLocationsService.GetBusLocationAsync(destinationId);

            var lastSearch = new VisitorLastSearchModel()
            {
                OriginId = originId,
                DestinationId = destinationId,
                OriginLocation = originLocation?.Name,
                DestinationLocation = destinationLocation?.Name,
                Date = date
            };

            _contextAccessor?.HttpContext?.Session.Set(SessionKeys.VisitorLastSearch, lastSearch);

            return lastSearch;
        }
    }
}