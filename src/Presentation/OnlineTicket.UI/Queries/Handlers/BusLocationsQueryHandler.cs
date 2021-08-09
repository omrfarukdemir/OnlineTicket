using AutoMapper;
using MediatR;
using OnlineTicket.Services;
using OnlineTicket.UI.Models.ViewModels;
using OnlineTicket.UI.Queries.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineTicket.UI.Queries.Handlers
{
    public class BusLocationsQueryHandler : IRequestHandler<BusLocationsQuery, BusLocationViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IBusLocationsService _busLocationsService;

        public BusLocationsQueryHandler(IMapper mapper, IBusLocationsService busLocationsService)
        {
            _mapper = mapper;
            _busLocationsService = busLocationsService;
        }

        public async Task<BusLocationViewModel> Handle(BusLocationsQuery request, CancellationToken cancellationToken)
        {
            var response = string.IsNullOrEmpty(request.Query)
                 ? await _busLocationsService.GetTopBusLocationsAsync()
                 : await _busLocationsService
                     .GetBusLocationsAsync(x => x.Name.ToLower().Contains(request.Query.ToLower()) || string.IsNullOrEmpty(request.Query));

            var suggestions = _mapper
                .Map<List<BusLocationListItem>>(response)
                .ToList(); ;

            return new BusLocationViewModel
            {
                Suggestions = suggestions
            };
        }
    }
}