using API.Model;

namespace API.Security
{
    public interface ITokenGenerator
    {
        Task<string> JWTGen(User user);
        string GenerateRefreshToken();

    }
}
