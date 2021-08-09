using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineTicket.UI.Queries.Models;
using System.Threading.Tasks;

namespace OnlineTicket.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class LookupController : BaseController
    {
        
        [HttpGet]
        public async Task<IActionResult> Pauses([FromQuery] string query)
        {
            return Ok(await Mediator.Value.Send(new BusLocationsQuery() { Query = query }));
        }
    }
}