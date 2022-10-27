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
        private readonly ICourseRepository _courseRepo;
        public CourseService(IMapper mapper, ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }

        public async Task<AddCourseDto> AddEntity(AddCourseDto dto)
        {
            var result =  await _courseRepo.AddAsync(dto);
            return result;
        }

        public async Task DeleteEntity(int id)
        {
             await _courseRepo.DeleteById(id);
        }

        public async Task<IEnumerable<CourseDto>> GetAllEntities()
        {
            var entity = await _courseRepo.GetAllAsync();
            return entity;
        }

        public async Task<CourseDto> GetEntityById(int id)
        {
            var entity = await _courseRepo.GetByIdAsync(id);
            var result = _mapper.Map<CourseDto>(entity);
            return result;
        }

        public async Task<UpdateCourseDto> UpdateEntity(UpdateCourseDto dto)
        {    
            var result = await _courseRepo.Update(dto);
            return result;
        }

       
    }
}
