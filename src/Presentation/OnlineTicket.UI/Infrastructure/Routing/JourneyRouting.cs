using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace OnlineTicket.UI.Infrastructure.Routing
{
    public static class JourneyRouting
    {
        public static void RegisterJourneyRouting(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "JourneyRoute",
                pattern: "seferler",
                defaults: new { controller = "Journey", action = "Index" });

            endpoints.MapControllerRoute(
                name: "JourneyListRoute",
                pattern: "seferler/{originId}-{destinationId}/{date}",
                defaults: new { controller = "Journey", action = "JourneyList" });
        }
    }
}