using API.Dto;

namespace API.Service.Interface
{
    public interface IUserService
    {
        bool AddAsync(UserDto entity);
        bool DeleteAsync(int id);
        Task<IEnumerable<UserDto>>GetAllAsync();
        UserDto GetUserByIdAsync(int id);
        bool UpdateAsync(UserDto entity);
    }
}
