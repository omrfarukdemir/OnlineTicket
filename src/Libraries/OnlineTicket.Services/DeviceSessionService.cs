using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineTicket.Clients.OBilet;
using OnlineTicket.Infrastructure.Extensions;
using OnlineTicket.Models.Clients.OBilet;
using OnlineTicket.Models.Clients.OBilet.Common;
using OnlineTicket.Models.Clients.OBilet.Request;
using OnlineTicket.Models.Services.DeviceSession;
using Wangkanai.Detection.Services;

namespace OnlineTicket.Services
{
    public class DeviceSessionService : IDeviceSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IObiletApiClient _apiClient;
        private readonly IDetectionService _detectionService;

        public DeviceSessionService(
            IHttpContextAccessor httpContextAccessor,
            IObiletApiClient apiClient,
            IDetectionService detectionService)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiClient = apiClient;
            _detectionService = detectionService;
        }

        public async ValueTask<DeviceSessionModel> GetDeviceSessionAsync()
        {
            var ipAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var port = _httpContextAccessor?.HttpContext?.Connection.RemotePort.ToString();

            var session =
                _httpContextAccessor?.HttpContext?.Session.Get<DeviceSessionModel>($"{ipAddress}_{port}") ?? await CreateSessionAsync();

            return session;
        }

        private async Task<DeviceSessionModel> CreateSessionAsync()
        {
            var ipAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var port = _httpContextAccessor?.HttpContext?.Connection.RemotePort.ToString();

            var result = await _apiClient.GetSession(new SessionRequest
            {
                Browser = new Browser()
                {
                    Version = _detectionService.Browser.Version.ToString(),
                    Name = _detectionService.Browser.Name.ToString()
                },
                Type = 1,
                Connection = new Connection()
                {
                    Port = port,
                    IpAddress = ipAddress
                }
            });

            if (result?.Content?.Status != ResponseStatus.Success)
            {
                throw new Exception(result?.Content?.UserMessage.ToString());
            }

            var session = new DeviceSessionModel()
            {
                DeviceId = result.Content.Data.DeviceId,
                SessionId = result.Content.Data.SessionId
            };

            _httpContextAccessor?.HttpContext?.Session.Set($"{ipAddress}_{port}", session);

            return session;
        }
    }
}