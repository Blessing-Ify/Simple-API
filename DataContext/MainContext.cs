using API.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.DataContext
{
    public class MainContext : IdentityDbContext<User>
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
    }
}
