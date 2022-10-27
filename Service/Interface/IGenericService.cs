namespace API.Service.Interface
{
    public interface IGenericService<T, X, Y, Z> where T : class
    {
        Task<IEnumerable<T>> GetAllEntities();
        Task<T> GetEntityById(X id);
        Task DeleteEntity(X id);
        Task<Y> AddEntity(Y dto); 
        Task<Z> UpdateEntity(Z dto);
    }
}
