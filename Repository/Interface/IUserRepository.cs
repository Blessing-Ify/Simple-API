using API.Dto;

namespace API.Repository.Interface
{
    public interface IUserRepository
    {
        Task Add(UserDto userDto);
        bool Delete(int Id);
        UserDto GetById(int Id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<bool> Save();
        Task Update(UserDto user);
    }
}
