using AutoMapper;
using OrderService.Domain;
using OrderService.ViewModel;

namespace OrderService.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
