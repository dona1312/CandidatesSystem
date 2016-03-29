using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITSystem.Enums;

namespace ITSystem.ViewModels.Consultants
{
    public class ConsultantEditVM : EditVM
    {
        [Required(ErrorMessage="Please input username! It is required!")]
        [StringLength(50, MinimumLength=3, ErrorMessage="Username must contain between 3 and 50 letters")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Username can consist only letters, spaces and dashes")]
        public string Username { get; set; }

        [Required(ErrorMessage="Please input password! It is required!")]
        [StringLength(50, MinimumLength=3, ErrorMessage="Password must contain between 3 and 50 letters")]
        public string Password { get; set; }

        [Required(ErrorMessage="Please input first name! It is required!")]
        [StringLength(50, MinimumLength=3, ErrorMessage="First name must contain between 3 and 50 letters")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "First name can consist only letters, spaces and dashes")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Please input last name! It is required!")]
        [StringLength(50, MinimumLength=3, ErrorMessage="Last name must contain between 3 and 50 letters")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Lastn name can consist only letters, spaces and dashes")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please input email! It is required!")]
        [StringLength(100, MinimumLength=5, ErrorMessage="Email must contain between 5 and 100 characters")]
        public string Email { get; set; }

        public RankEnum Rank { get; set; }
    }
}