using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public virtual IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public decimal TotalValue
        {
            get { return items.Sum(i => i.SubTotal); }
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartItem item = items.Where(i => i.Product.ProductId == product.ProductId).FirstOrDefault();
            if (item == null)
            {
                item = new CartItem { Product = product, Quantity = quantity };
                items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public virtual void Clear()
        {
            items.Clear();
        }

        public virtual void RemoveItem(Product product)
        {
            items.RemoveAll(i => i.Product.ProductId == product.ProductId);
        }
    }
}
