namespace InsuranceQuote.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        bool UpdateRange(List<T> entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task Delete(T entity);
        bool DeleteRange(List<T> entity);
        void Dispose();
        Task<int> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);
    }
}