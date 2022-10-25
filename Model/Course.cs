namespace API.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Cost { get; set; }
        public string? Author { get; set; }
        public List<UserCourse> Users { get; set; }
        public Course()
        {
            Users = new List<UserCourse>();
        }
    }
}
