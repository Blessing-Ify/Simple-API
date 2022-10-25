namespace API.Repository.Interface
{
    public interface IRepositoryWrapper
    {
        ICourseRepository CourseRepo { get; }
        IUserRepository UserRepo { get; }
    }
}
