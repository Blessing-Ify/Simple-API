using API.DataContext;
using API.Dto;
using API.Model;
using API.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implementation
{
    [Authorize]
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        
        public CourseRepository(MainContext context)
            : base(context)
        {
        }

        public void AddCourse(Course entity)
        {
            Add(entity);
        }

        public void DeleteCourse(Course entity)
        {
            Delete(entity);
        }

        public async Task<IEnumerable<Course>> GetAllCourseAsync()
        {
            return await GetAll().OrderBy(c => c.CourseName ).ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await GetByCondition(c => c.Id.Equals(courseId))
                        .FirstOrDefaultAsync();
        }
                               
        public async Task<Course> GetCourseWithDetailsAsync(int courseId)
        {
            return await GetByCondition(c => c.Id.Equals(courseId))
                        .Include(ac => ac.Users)
                        .FirstOrDefaultAsync();
        }

        public void UpdateCourse(Course entity)
        {
            Update(entity);
        }
    }
}
