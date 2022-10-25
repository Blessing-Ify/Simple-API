using API.DataContext;
using API.Repository.Interface;

namespace API.Repository.Implementation
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MainContext _context;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        public RepositoryWrapper(MainContext context)
        {
            _context = context;
            _courseRepository = new Lazy<ICourseRepository>(() => new
            CourseRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new
            UserRepository(context));
        }
        public ICourseRepository CourseRepo => _courseRepository.Value;
        public IUserRepository UserRepo => _userRepository.Value;                
    }
}
