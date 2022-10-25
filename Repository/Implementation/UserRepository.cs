using API.DataContext;
using API.Dto;
using API.Model;
using API.Repository.Interface;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implementation
{
    public class UserRepository : GenericRepository<Course>, IUserRepository
    {

        public UserRepository(MainContext context)
             : base(context)
        {
        }

        public Task Add(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDto user)
        {
            throw new NotImplementedException();
        }
        /* public async Task Add(UserDto userDto)
{
    var user = _mapper.Map<User>(userDto);
        await _context.Users.AddAsync(user);
}

public bool Delete(int id)
{
  var result =  _context.Users.FirstOrDefault(e => e.Id == id.ToString());
    if (result == null)
        return false;
    _context.Users.Remove(result);
    return true;
}

public UserDto GetById(int id)
{
    var user =  _context.Users.FirstOrDefault(e => e.Id == id.ToString());
    if(user == null)
        return null;
    var result = _mapper.Map<UserDto>(user);
    return result;
}

public async Task<IEnumerable<UserDto>> GetAll()
{
    var UserList = await _context.Users.AsNoTracking()
                   .ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync();
    return UserList;
}

public async Task<bool> Save()
{
   return await _context.SaveChangesAsync() > 0;
}

public async Task Update(UserDto userDto)
{
    var updateUser = _mapper.Map<User>(userDto);
    await _context.Users.AddAsync(updateUser);
}*/
    }
}


