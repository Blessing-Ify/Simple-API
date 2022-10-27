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
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;

        public UserRepository(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<UserDto> AddAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null) 
                _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var allUsers = await _context.Users.ToListAsync();
            var users = _mapper.Map<IEnumerable<UserDto>>(allUsers);
            return users;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UpdateUserDto> Update(UpdateUserDto dto)
        {
            var newUser = _mapper.Map<User>(dto);
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == newUser.Id);
            if (user != null)
                // _mapper.Map(course, newCourse);
                user.Id = newUser.Id;
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.Email = newUser.Email;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<UpdateUserDto>(user);
            return result;
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }                
    }
}