using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class AdminRegistrationViewModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please choose a password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
