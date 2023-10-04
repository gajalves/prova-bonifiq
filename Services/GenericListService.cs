using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class GenericListService<T> : IGenericListService<T> where T : Base
    {
        
        private readonly IBaseRepository<T> _baseRepository;

        const int DefaultPageSize = 10;

        public GenericListService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<GenericList<T>> ListAsync(int page)
        {
            var items = await _baseRepository.GetPaginatedAsync(DefaultPageSize, page);

            var totalCount = await _baseRepository.CountAsync();

            return new GenericList<T>(items, totalCount, page, DefaultPageSize);
        }
    }
}
