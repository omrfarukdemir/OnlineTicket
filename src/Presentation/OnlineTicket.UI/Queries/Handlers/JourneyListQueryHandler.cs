using AutoMapper;
using MediatR;
using OnlineTicket.Clients.OBilet;
using OnlineTicket.Models.Clients.OBilet;
using OnlineTicket.Models.Clients.OBilet.Request;
using OnlineTicket.Models.Clients.OBilet.RequestData;
using OnlineTicket.Services;
using OnlineTicket.UI.Models.ViewModels;
using OnlineTicket.UI.Queries.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineTicket.UI.Queries.Handlers
{
    public class JourneyListQueryHandler : IRequestHandler<JourneyListQuery, JourneyListViewModel>
    {
        private readonly IObiletApiClient _obiletApiClient;
        private readonly IVisitorService _visitorService;
        private readonly IMapper _mapper;

        public JourneyListQueryHandler(
            IObiletApiClient obiletApiClient,
            IVisitorService visitorService,
            IMapper mapper)
        {
            _obiletApiClient = obiletApiClient;
            _visitorService = visitorService;
            _mapper = mapper;
        }

        public async Task<JourneyListViewModel> Handle(JourneyListQuery request, CancellationToken cancellationToken)
        {
            var response = await _obiletApiClient.GetBusJourneys(new BusJourneysRequest()
            {
                Date = request.Date,
                Language = request.Language,
                DeviceSession = request.DeviceSession,
                Data = new BusJourneysRequestData()
                {
                    DestinationId = request.DestinationId,
                    OriginId = request.OriginId,
                    DepartureDate = request.Date.ToString("yyyy-MM-dd"),
                }
            });

            if (response?.Content?.Status != ResponseStatus.Success)
            {
                throw new Exception(response?.Content?.UserMessage.ToString());
            }

            var journeyListItems = _mapper.Map<List<JourneyListItem>>(response.Content?.Data);

            var visitorLastSearch = await _visitorService.SetVisitorLastSearch(request.OriginId, request.DestinationId, request.Date);

            var result = new JourneyListViewModel()
            {
                Journey = journeyListItems,
            };

            return _mapper.Map(visitorLastSearch, result);
        }
    }
}