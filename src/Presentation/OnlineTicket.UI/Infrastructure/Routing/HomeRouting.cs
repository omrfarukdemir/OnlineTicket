using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace OnlineTicket.UI.Infrastructure.Routing
{
    public static class HomeRouting
    {
        public static void RegisterHomeRouting(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}