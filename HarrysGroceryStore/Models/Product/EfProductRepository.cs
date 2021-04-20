using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class EfProductRepository : IProductRepository
    {
        private AppDbContext _context;

        public EfProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public IQueryable<string> GetAllCategories()
        {
            IQueryable<string> categories = _context.Products.Select(p => p.Category).Distinct().OrderBy(c => c);
            return categories;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProductById(int productId)
        {
            Product p = _context.Products.Find(productId);
            return p;
        }

        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            IQueryable<Product> products = _context.Products.Where(p => p.ProductName.Contains(keyword));
            return products;
        }

        public Product UpdateProduct(Product product)
        {
            Product productToUpdate = _context.Products.Find(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Price = product.Price;
                productToUpdate.Category = product.Category;
                _context.SaveChanges();
            }
            return productToUpdate;
        }

        public bool DeleteProduct(int id)
        {
            Product productToDelete = GetProductById(id);
            if (productToDelete == null)
            {
                return false;
            }
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
