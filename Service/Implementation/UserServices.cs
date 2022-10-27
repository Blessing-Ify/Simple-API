using API.Dto;
using API.Model;
using API.Repository.Interface;
using API.Service.Interface;
using AutoMapper;

namespace API.Service.Implementation
{
    public class UserServices : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        public UserServices(IMapper mapper, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public Task<UserDto> AddEntity(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEntity(string id)
        {
            await _userRepo.DeleteById(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllEntities()
        {
            var entity = await _userRepo.GetAllAsync();
            return entity;
        }

        public async Task<UserDto> GetEntityById(string id)
        {
            var entity = await _userRepo.GetByIdAsync(id);
            var result = _mapper.Map<UserDto>(entity);
            return result;
        }

        public async Task<UpdateUserDto> UpdateEntity(UpdateUserDto dto)
        {
            var result = await _userRepo.Update(dto);
            return result;
        }
    }
}