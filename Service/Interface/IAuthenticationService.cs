using API.Dto;
using Microsoft.AspNetCore.Identity;

namespace API.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegisterDto userRegistration);
        Task<bool> ValidateUser(UserLoginDto loginDto);
        Task<string> CreateToken();

    }
}
