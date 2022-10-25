using Microsoft.AspNetCore.Identity;

namespace API.Model
{
    public class User :IdentityUser
    {
        //public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string Email { get; set; }
        //public string Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public List<UserCourse> UserCourse { get; set; }
        public User()
        {
            UserCourse = new List<UserCourse>();
        }
    }
}
