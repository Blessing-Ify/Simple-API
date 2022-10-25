using API.Dto;
using API.Service.Interface;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var user = _userService.GetAllAsync();
            return Ok(user);
        }

        [HttpGet("{id:int}", Name = "UserById")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("user object is null");
            var user = _userService.AddAsync(userDto);
            return CreatedAtRoute("UserById", user);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
            if (userDto == null)
                return BadRequest("User object is null");
            _userService.UpdateAsync(userDto);
            return NoContent();
        }
    }
}
