using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please choose a password")]
        [MaxLength(14, ErrorMessage = "Password cannot exceed 14 characters")]
        public string PassWord { get; set; }
    }
}
