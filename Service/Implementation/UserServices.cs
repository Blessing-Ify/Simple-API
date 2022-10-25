using API.Dto;
using API.Repository.Interface;
using API.Service.Interface;

namespace API.Service.Implementation
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserServices(IUserRepository userRepo)
        {
            _userRepo = userRepo;   
        }
        public bool AddAsync(UserDto entity)
        {
            var result = _userRepo.Add(entity);
            _userRepo.Save();
            if(result == null)
                return false;
            return true;
        }

        public bool DeleteAsync(int id)
        {
            var result = _userRepo.Delete(id);
            _userRepo.Save();
            if (result == false)
                return false;
            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _userRepo.GetAll();            
        }

        public UserDto GetUserByIdAsync(int id)
        {
            return _userRepo.GetById(id);
        }

        public bool UpdateAsync(UserDto entity)
        {
            var result = _userRepo.Update(entity);
            _userRepo.Save();
            if (result == null)
                return false;
            return true;
        }
    }
}
