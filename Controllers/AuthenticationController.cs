using API.Dto;
using API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegistration)
        {
            var result = await _authService.RegisterUser(userRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto  user)
        {
            if (!await _authService.ValidateUser(user))
                return Unauthorized();
            return Ok(new
            {
                Token = await _authService.CreateToken()
            });
        }
    }
}
