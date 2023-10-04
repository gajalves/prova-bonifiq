using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly TestDbContext _ctx;

        public BaseRepository(TestDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public virtual async Task<List<T>> GetPaginatedAsync(int pageSize, int page)
        {
            if (page <= 0)
                page = 1;

            return await _ctx.Set<T>()
                             .Skip(pageSize * (page - 1))
                             .Take(pageSize)
                             .ToListAsync();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _ctx.Set<T>().CountAsync();
        }
    }
}
