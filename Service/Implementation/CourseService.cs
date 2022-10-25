using API.Dto;
using API.Model;
using API.Repository.Interface;
using API.Service.Interface;
using AutoMapper;

namespace API.Service.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repoWrapper;
        public CourseService(IMapper mapper, IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        public bool AddAsync(CourseDto course)
        {
            if (course == null)
                return false;
            var entity = _mapper.Map<Course>(course);
            _repoWrapper.CourseRepo.AddCourse(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _repoWrapper.CourseRepo.GetCourseByIdAsync(id);
            if (course == null)
                return false;
            _repoWrapper.CourseRepo.DeleteCourse(course);
            return true;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _repoWrapper.CourseRepo.GetAllCourseAsync();
            var Result = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Result;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var courses = await _repoWrapper.CourseRepo.GetCourseByIdAsync(id);
            if (courses == null)
                throw new Exception();
            return _mapper.Map<UserDto>(courses);   
        }

        public async Task<bool> UpdateAsync(CourseDto courseDto, int id)
        {
            if (courseDto == null)
                return false;
            var entity =  await _repoWrapper.CourseRepo.GetCourseByIdAsync(id);
            if (entity == null)
                return false;
            _mapper.Map(courseDto, entity);
            _repoWrapper.CourseRepo.UpdateCourse(entity);
            return true;

        }
                
    }
}
