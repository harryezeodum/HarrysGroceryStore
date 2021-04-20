using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    [Table("Users")]
    
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please choose a password")]
        [MaxLength(14, ErrorMessage = "Password cannot exceed ten characters")]
        public string PassWord { get; set; }
    }
}
