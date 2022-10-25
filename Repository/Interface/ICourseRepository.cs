using API.Dto;
using API.Model;

namespace API.Repository.Interface
{
    public interface ICourseRepository : IGenericRepository<Course>
    {        
        Task<IEnumerable<Course>> GetAllCourseAsync();
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<Course> GetCourseWithDetailsAsync(int courseId);
        void AddCourse(Course entity);
        void DeleteCourse(Course entity); 
        void UpdateCourse(Course entity);
    }
}
