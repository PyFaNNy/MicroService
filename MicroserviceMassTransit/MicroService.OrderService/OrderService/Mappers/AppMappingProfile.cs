using AutoMapper;
using MassTransit.Contracts.ViewModels;
using OrderService.Domain;

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
