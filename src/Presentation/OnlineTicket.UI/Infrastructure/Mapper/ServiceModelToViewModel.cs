using AutoMapper;
using OnlineTicket.Models.Services.Visitor;
using OnlineTicket.UI.Models.ViewModels;

namespace OnlineTicket.UI.Infrastructure.Mapper
{
    public class ServiceModelToViewModel : Profile
    {
        public ServiceModelToViewModel()
        {
            CreateMap<VisitorLastSearchModel, JourneyListViewModel>()
                .ForMember(x => x.Date, x => x.MapFrom(m => m.Date.ToString("yyyy-MM-dd")));
        }
    }
}