using API.DataContext;
using API.Dto;
using API.Model;
using API.Repository.Interface;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implementation
{    
    public class CourseRepository : ICourseRepository
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(MainContext context, IMapper mapper)            
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddCourseDto> AddAsync(AddCourseDto dto)
        {
            var entity = _mapper.Map<Course>(dto);
            var course = await _context.Courses.AddAsync(entity);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AddCourseDto>(course);
            return result;
        }

        public async Task DeleteById(int id)
        {
            var course =  await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course != null) 
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var allCourses = await _context.Courses.AsNoTracking()
                .ProjectTo<CourseDto>(_mapper.ConfigurationProvider).ToListAsync();
            return allCourses;
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task<UpdateCourseDto> Update(UpdateCourseDto dto)
        {
            var newCourse = _mapper.Map<Course>(dto);
            var course = await _context.Courses.FirstOrDefaultAsync(e => e.Id == newCourse.Id);
            if (course != null)
            // _mapper.Map(course, newCourse);
            course.Id = newCourse.Id;
            course.CourseName = newCourse.CourseName;
            course.Cost = newCourse.Cost;
            course.Author = newCourse.Author;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<UpdateCourseDto>(course);
            return result;
        }
        public async void Save()
        {
            await _context.SaveChangesAsync();            
        }
    }
}
