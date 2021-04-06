using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [MaxLength(12, ErrorMessage = "Phone number cannot exceed ten characters")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please choose a password")]
        [MaxLength(10, ErrorMessage = "Password cannot exceed ten characters")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [MaxLength(10, ErrorMessage = "Password cannot exceed ten characters")]
        public string ConfirmPassword { get; set; }
    }
}
