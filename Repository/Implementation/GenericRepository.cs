using API.DataContext;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected  MainContext _context { get; set; }

        public GenericRepository(MainContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();

        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
