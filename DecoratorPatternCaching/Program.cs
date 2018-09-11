using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternCaching
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new CacheProductService();
            List<Product> products = productService.GetAllProducts();
            Console.WriteLine("All Products");
            for(int i=0;i<products.Count;i++)
            {
                Console.WriteLine("ProductId:- " + products[i].Id);
                Console.WriteLine("ProductName:- " + products[i].name);
                Console.WriteLine("ProductPrice:- " + products[i].price);
                Console.WriteLine();
            }
            Console.WriteLine("Enter productId which u want to search");
            int id = int.Parse(Console.ReadLine());
            Product product = productService.GetProductById(id);
            Console.WriteLine("ProductId:- " + product.Id);
            Console.WriteLine("ProductName:- " + product.name);
            Console.WriteLine("ProductPrice:- " + product.price);
            Console.WriteLine("Enter productId which u want to search");
            Console.WriteLine();
            id = int.Parse(Console.ReadLine());
            product = productService.GetProductById(id);
            Console.WriteLine("ProductId:- "+product.Id);
            Console.WriteLine("ProductName:- " + product.name);
            Console.WriteLine("ProductPrice:- " + product.price);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
