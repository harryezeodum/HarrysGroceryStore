using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    [Table("SalesOrders")]

    public class SalesOrder
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [ForeignKey("OrderDetailId")]
        public int OrderDetailId { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal SalesAmount { get; set; }

        public string OrderDate { get; set; }

        public string ShippedDate { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }
    }
}
