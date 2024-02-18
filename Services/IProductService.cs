using APSTUnitTesting.Models;

namespace APSTUnitTesting.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> Get();
        public Product? Get(int id);
        Product AddProduct(Product product);

    }
}
