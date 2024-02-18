using APSTUnitTesting.Models;

namespace APSTUnitTesting.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products = new List<Product>()
        {
            new Product(){ Id=1, Name = "Teclado", Brand = "Logitec", Quantity = 12 },
            new Product(){ Id=2, Name = "Monitor", Brand = "Sceptre", Quantity = 9   },
            new Product(){ Id=3, Name = "Mouse", Brand = "Dell", Quantity = 4 }
        };

        public IEnumerable<Product> Get() => _products;

        public Product? Get(int id) => _products.FirstOrDefault(p => p.Id == id);

        public Product AddProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                throw new ArgumentException("Un producto con el mismo ID ya existe.");
            }

            _products.Add(product);
            return product;
        }
    }
}
