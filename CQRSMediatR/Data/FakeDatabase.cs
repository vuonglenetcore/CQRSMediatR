using CQRSMediatR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatR.Data
{
    public class FakeDatabase
    {
        private static List<Product> _products;

        public FakeDatabase()
        {
            _products = new List<Product>()
            {
                new Product{Id = 1, Name = "Product 1" },
                new Product{Id = 2, Name = "Product 2" },
                new Product{Id = 3, Name = "Product 3" }
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = _products.Single(x => x.Id == id);
            return await Task.FromResult(product);
        }

        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(x => x.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}