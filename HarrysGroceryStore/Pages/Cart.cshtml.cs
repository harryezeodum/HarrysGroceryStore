using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrysGroceryStore.Infrastructure;
using HarrysGroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HarrysGroceryStore.Pages
{
    public class CartModel : PageModel
    {
        private IProductRepository _repository;

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IProductRepository repository)
        {
            _repository = repository;
        }

        public void OnGet(string returnUrl = "/")
        {
            ReturnUrl = returnUrl;

            Cart = HttpContext.Session.GetJson<Cart>("cart");
            if (Cart == null)
            {
                Cart = new Cart();
            }
        }

        public void OnPost(int productId, string returnUrl = "/")
        {
            ReturnUrl = returnUrl;

            Cart = HttpContext.Session.GetJson<Cart>("cart");
            if (Cart == null)
            {
                Cart = new Cart();
            }

            Product product = _repository.GetProductById(productId);

            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            HttpContext.Session.SetJson("cart", Cart);
        }
    }
}
