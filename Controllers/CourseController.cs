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
        public async Task<ActionResult<CourseDto>> GetAllCourses()
        {
            try
            {
                var course = await _courseService.GetAllEntities();
                return Ok(course);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error retrieving data from the database");
            }           
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(int id)
        {
            try
            {
                var course = await _courseService.GetEntityById(id);

                if (course == null)
                {
                    return BadRequest("Id not found");
                }
                return course;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }            
        }

        [HttpPost]
        public async Task<ActionResult<AddCourseDto>> AddCourse([FromBody] AddCourseDto courseDto)
        {
            try
            {
                var course = await _courseService.AddEntity(courseDto);
                return Ok(course);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in adding course to the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {            
            try
            {
                var course = await _courseService.GetEntityById(id);
                if (course == null)
                    return NotFound($"Course with Id = {id} was not found");
                await _courseService.DeleteEntity(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCourseDto>> UpdateCourse(int id, [FromBody] UpdateCourseDto courseDto)
        {
            try
            {
                if (id != courseDto.Id)
                    return BadRequest("Mismatched Id!");
                await _courseService.UpdateEntity(courseDto);
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
