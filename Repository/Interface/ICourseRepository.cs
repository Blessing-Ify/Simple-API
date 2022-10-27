using API.Dto;
using API.Model;

namespace API.Repository.Interface
{
    public interface ICourseRepository : IGenericRepository<CourseDto, int, AddCourseDto, UpdateCourseDto>
    {  
        
    }
}
