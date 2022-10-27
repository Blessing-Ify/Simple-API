using API.Dto;
using API.Model;
using AutoMapper;

namespace API.Settings
{
    public class Automapper : Profile
    {
        public Automapper()
        {

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, AddCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegisterDto, User>()
                .ForMember(d => d.UserName, map => map.MapFrom(s => s.Email));
            //reverse is for biderectional mapping no need checking for source and destination

        }
    }
}
