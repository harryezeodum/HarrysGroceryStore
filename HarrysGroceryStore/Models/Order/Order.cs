using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    [Table("Orders")]

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal SalesAmount { get; set; }

        public string OrderDate { get; set; }

        public string ShippedDate { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
