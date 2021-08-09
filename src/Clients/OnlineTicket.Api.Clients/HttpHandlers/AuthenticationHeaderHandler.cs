using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineTicket.Clients.OBilet.HttpHandlers
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly IConfiguration _configuration;

        public AuthenticationHeaderHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authentication = request.Headers.Authorization;

            if (authentication is not null) return base.SendAsync(request, cancellationToken);

            authentication = new AuthenticationHeaderValue("Basic", _configuration["Obilet:Token"]);

            request.Headers.Authorization = authentication;

            return base.SendAsync(request, cancellationToken);
        }
    }
}