namespace API.Dto
{
    public class UpdateCourseDto
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Cost { get; set; }
        public string? Author { get; set; }
    }
}
