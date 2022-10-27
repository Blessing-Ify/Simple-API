using API.Dto;
using API.Service.Interface;
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
        public async Task<ActionResult<UserDto>> GetAllUsers()
        {
            try
            {
                var user = await _userService.GetAllEntities(); 
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            try
            {
                var user = await _userService.GetEntityById(id);

                if (user == null)
                {
                    return BadRequest("Id not found");
                }
                return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _userService.GetEntityById(id);
                if (user == null)
                    return NotFound($"Course with Id = {id} was not found");
                await _userService.DeleteEntity(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserDto>> UpdateCourse(string id, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                if (id != userDto.Id)
                    return BadRequest("Mismatched Id!");
                await _userService.UpdateEntity(userDto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating course");
            }
        }

    }
}
