using API.Dto;

namespace API.Service.Interface
{
    public interface ICourseService : IGenericService<CourseDto, int, AddCourseDto, UpdateCourseDto>
    {
       
    }
}
