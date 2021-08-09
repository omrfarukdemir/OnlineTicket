using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace OnlineTicket.UI.Controllers
{
    public class BaseController : Controller
    {
        public Lazy<IMediator> Mediator => new(HttpContext.RequestServices.GetService<IMediator>());
    }
}