using AutoMapper;
using UserService.Domain;
using UserService.ViewModels;

namespace UserService.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
