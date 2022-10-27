using System.Linq.Expressions;

namespace API.Repository.Interface
{
    public interface IGenericRepository<T, X, Y, Z> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(X id);
        Task<Y> AddAsync(Y dto);
        Task DeleteById(X id);
        Task<Z> Update(Z dto);
        void Save();
        /*Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        bool DeleteById(int id);
        Task AddAsync(Y entity);
        Task UpdateAsync(Z entity);
        Task<bool> Save(CancellationToken cancellationToken);*/

    }
}
