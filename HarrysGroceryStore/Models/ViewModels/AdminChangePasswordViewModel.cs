using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrysGroceryStore.Models
{
    public class AdminChangePasswordViewModel
    {
        [Required(ErrorMessage = "Please enter your old password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please enter your new password")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Passwords don't match")]
        [Required(ErrorMessage = "Please confirm your new password")]
        public string VerifyNewPassword { get; set; }
    }
}
