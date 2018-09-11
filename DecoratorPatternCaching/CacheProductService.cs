using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternCaching
{
    class CacheProductService : ICacheProductService
    {
        private IProductService _productService;
        private CacheProvider _CacheProvider;
        public CacheProductService()
        {
            _productService = new ProductService();
            _CacheProvider = new CacheProvider();
        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = _productService.GetAllProducts();
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = (Product)_CacheProvider.GetItem(Convert.ToString(id));
            if (product != null)
            {
                Console.WriteLine("Getting items from Cache");
                return product;
            }
            product = _productService.GetProductById(id);
            _CacheProvider.AddItem(Convert.ToString(product.Id), product);
            return product;
        }
    }
}
