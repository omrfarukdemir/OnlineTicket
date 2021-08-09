using OnlineTicket.Models.Services.Visitor;
using System;
using System.Threading.Tasks;

namespace OnlineTicket.Services
{
    public interface IVisitorService
    {
        ValueTask<VisitorLastSearchModel> GetVisitorLastSearchAsync();

        ValueTask<VisitorLastSearchModel> SetVisitorLastSearch(int originId, int destinationId, DateTime date);
    }
}