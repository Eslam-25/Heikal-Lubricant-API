using AutoMapper;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Dtos.ViewModels;
using Heikal.Lubricant.Core.Entities;

namespace Heikal.Lubricant.Core.Mapping
{
    public class AppMappingProfiler: Profile
    {
        public AppMappingProfiler()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, ClientViewDto>();
            CreateMap<Days, DaysDto>().ReverseMap();
            CreateMap<Line, LineDto>().ReverseMap();
            CreateMap<Line, LineViewDto>()
                .ForMember(dst => dst.DayName , opt => opt.MapFrom(src => src.Day.DayName));
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserViewModel>()
                .ForMember(dst => dst.RoleName , opt => opt.MapFrom(src => src.Role.RoleName));
            CreateMap<User, UserLoginViewModel>()
                .ForMember(dst => dst.Role, opt => opt.MapFrom(src => src.Role.RoleName));
        }
    }
}
