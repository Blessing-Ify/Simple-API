using API.Dto;

namespace API.Service.Interface
{
    public interface ICourseService
    {
        bool AddAsync(CourseDto course);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<bool> UpdateAsync(CourseDto entity, int id);
    }
}
