using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITSystem.ViewModels.Account
{
    public class AccountLoginVM
    {
        [Required(ErrorMessage = "Please input username! It is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must contain between 3 and 50 letters")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Username can consist only letters, spaces and dashes")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please input password! It is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Password must contain between 3 and 50 letters")]
        public string Password { get; set; }
       
        public string RedirectUrl { get; set; }      
    }
}