using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternCaching
{
    class ProductService : IProductService
    {
        public List<Product> GetAllProducts()
        {
            IRepository productRepository = new SQLRepository();
            return productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            IRepository productRepo = new SQLRepository();
            Console.WriteLine("From Repository");
            return productRepo.GetProductById(id);
        }
    }
}
