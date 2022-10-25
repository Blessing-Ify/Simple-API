/*using API.Model;

namespace API.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _config;
        public TokenGenerator(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> GenerateToken(User user)
        {
            var JWTstring = _config.GetSection("JWT");
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTstring["Key"]));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512);
            var getTime = JWTstring.GetValue<int>("ExpiryTime");

            var tokenOptions = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                //claims: claims,
                expires: DateTime.Now.AddMinutes(getTime),
                signingCredentials: creds

              );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
*/