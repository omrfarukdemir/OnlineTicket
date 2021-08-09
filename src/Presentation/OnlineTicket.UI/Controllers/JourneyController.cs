using Microsoft.AspNetCore.Mvc;
using OnlineTicket.UI.Queries.Models;
using System.Threading.Tasks;
using OnlineTicket.UI.Models.RequestModel;

namespace OnlineTicket.UI.Controllers
{
    public class JourneyController : BaseController
    {
        [HttpPost, HttpGet]
        public IActionResult Index([FromForm] JourneyListRequest request)
        {
            return RedirectToRoute("JourneyListRoute", new
            {
                originId = request.OriginId,
                destinationId = request.DestinationId,
                date = request.Date.ToString("yyyy-MM-dd")
            });
        }

        public async Task<IActionResult> JourneyList([FromRoute] JourneyListQuery query)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(await Mediator.Value.Send(query));
        }
    }
}