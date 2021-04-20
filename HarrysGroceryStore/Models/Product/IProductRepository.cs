using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public interface IProductRepository
    {
        public Product AddProduct(Product product);

        public IQueryable<Product> GetAllProducts();

        public Product GetProductById(int productId);

        public IQueryable<Product> GetProductsByKeyword(string keyword);

        public IQueryable<string> GetAllCategories();

        public Product UpdateProduct(Product product);

        public bool DeleteProduct(int id);
    }
}
