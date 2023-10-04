using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<List<T>> GetPaginatedAsync(int pageSize, int page);
        Task<int> CountAsync();
    }
}
