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

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [MaxLength(12, ErrorMessage = "Phone number cannot exceed ten characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please choose a password")]
        [MaxLength(14, ErrorMessage = "Password cannot exceed ten characters")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [MaxLength(14, ErrorMessage = "Password cannot exceed ten characters")]
        public string ConfirmPassword { get; set; }
    }
}
