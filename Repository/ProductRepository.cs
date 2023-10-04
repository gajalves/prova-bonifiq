using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(TestDbContext ctx) : base(ctx)
        {
        }
    }
}
