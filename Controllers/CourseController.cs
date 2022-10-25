using API.Dto;
using API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {        
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var course = _courseService.GetAllAsync();
            return Ok(course);
        }

        [HttpGet("{id:int}", Name = "CourseById")]
        public IActionResult GetCourse(int id)
        {
            var course = _courseService.GetUserByIdAsync(id);
            return Ok(course);
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] CourseDto courseDto)
        {
            /*if (courseDto == null)
                return BadRequest("user object is null");*/
            var course = _courseService.AddAsync(courseDto);
            return CreatedAtRoute("CourseById", course);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            _courseService.DeleteAsync(id);
            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseDto courseDto)
        {            
            _courseService.UpdateAsync(courseDto, id);
            return NoContent();
        }

    }
}
