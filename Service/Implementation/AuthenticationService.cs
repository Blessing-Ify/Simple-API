using API.Dto;
using API.Model;
using API.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;       
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;

        public AuthenticationService(IMapper mapper, IConfiguration configuration,
        UserManager<User> userManager)
        {
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDto userRegistration)
        {
            var user = _mapper.Map<User>(userRegistration);
            return await _userManager.CreateAsync(user, userRegistration.Password);
        }
        public async Task<bool> ValidateUser(UserLoginDto userLogin)
        {
            _user = await _userManager.FindByNameAsync(userLogin.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userLogin.Password));
            /*if (!result)
                _logger.LogWarning($"{nameof(ValidateUser)}: Authentication failed. Wrong email or password.");*/
            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SECRET"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>{new Claim(ClaimTypes.Email, _user.Email)};            
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryTime"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
