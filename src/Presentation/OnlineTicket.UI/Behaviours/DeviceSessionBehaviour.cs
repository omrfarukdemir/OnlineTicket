using MediatR;
using OnlineTicket.Models.Clients.OBilet;
using OnlineTicket.Models.Clients.OBilet.Common;
using OnlineTicket.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineTicket.UI.Behaviours
{
    public class DeviceSessionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : BaseRequest
    {
        private readonly IDeviceSessionService _deviceSessionService;

        public DeviceSessionBehaviour(IDeviceSessionService deviceSessionService)
        {
            _deviceSessionService = deviceSessionService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var deviceSession = await _deviceSessionService.GetDeviceSessionAsync();

            request.DeviceSession = new DeviceSession() { DeviceId = deviceSession.DeviceId, SessionId = deviceSession.SessionId };
            request.Language = "tr-TR";
            request.Date = DateTime.Now;

            return await next();
        }
    }
}