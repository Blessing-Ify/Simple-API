using API.Dto;
using API.Model;
using AutoMapper;

namespace API.Settings
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegisterDto, User>()
                .ForMember(d => d.UserName, map => map.MapFrom(s => s.Email));

        }
    }
}
