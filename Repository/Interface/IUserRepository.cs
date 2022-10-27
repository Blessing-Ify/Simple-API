using API.Dto;
using API.Model;

namespace API.Repository.Interface
{
    public interface IUserRepository : IGenericRepository<UserDto, string, UserDto, UpdateUserDto>
    {

    }
}
