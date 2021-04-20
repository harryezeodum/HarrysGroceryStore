using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    [Table("Products")]
    
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [Column(TypeName = "decimal(8, 2")]
        public decimal Price { get; set; }

        public string Category { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
    }
}
