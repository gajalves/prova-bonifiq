using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService : GenericListService<Product>, IProductService
    {
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
        }
    }
}
