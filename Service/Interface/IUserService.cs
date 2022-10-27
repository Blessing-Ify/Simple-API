using API.Dto;

namespace API.Service.Interface
{
    public interface IUserService : IGenericService<UserDto, string, UserDto, UpdateUserDto>
    {

    }
}
