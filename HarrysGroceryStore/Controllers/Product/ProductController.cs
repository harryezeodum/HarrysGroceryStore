using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Controllers
{
    public class ProductController : Controller
    {
        private int _pageSize = 10;
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _repository.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult ProductCategories()
        {
            IQueryable<string> categories = _repository.GetAllCategories();
            return View(categories);
        }

        public IActionResult Index(int productPage = 1)
        {
            IQueryable<Product> allProducts = _repository.GetAllProducts();
            IQueryable<Product> someProducts = allProducts.OrderBy(p => p.ProductId).Skip((productPage - 1) * _pageSize).Take(_pageSize);

            ListViewModel lvm = new ListViewModel();

            PagingInfo pi = new PagingInfo();
            pi.TotalItems = allProducts.Count();
            pi.ItemsPerPage = _pageSize;
            pi.CurrentPage = productPage;

            lvm.PagingInformation = pi;

            lvm.Products = someProducts;

            return View(lvm);
        }

        public IActionResult ProductDetail(int id)
        {
            Product product = _repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchProduct(string keyword)
        {
            IQueryable<Product> product = _repository.GetProductsByKeyword(keyword);
            return View(product);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            Product product = _repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            Product updatedProduct = _repository.UpdateProduct(product);
            return RedirectToAction("ProductDetail", new { id = product.ProductId });
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product, int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
