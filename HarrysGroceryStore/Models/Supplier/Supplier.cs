using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    [Table("Suppliers")]

    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }

        public List<Product> Products { get; set; }
    }
}
