using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IGenericListService<T> where T : Base
    {
        Task<GenericList<T>> ListAsync(int page);
    }
}
