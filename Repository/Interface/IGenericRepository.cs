using System.Linq.Expressions;

namespace API.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();

    }
}
