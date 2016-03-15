using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSystem.ViewModels.Candidates
{
    public class CandidateEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please input first name! It is required!")]
        [StringLength(70, MinimumLength=3, ErrorMessage="First name must contain between 3 and 70 letters")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "First name can consist only letters, spaces and dashes")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Please input middle name! It is required!")]
        [StringLength(70, MinimumLength=3, ErrorMessage="Middle name must contain between 3 and 70 letters")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Middle name can consist only letters, spaces and dashes")]
        [Display(Name="Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage="Please input last name! It is required!")]
        [StringLength(70, MinimumLength=3, ErrorMessage="Last name must contain between 3 and 70 letters")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Last name can consist only letters, spaces and dashes")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please input email! It is required!")]
        [StringLength(100, MinimumLength=5, ErrorMessage="Email must contain between 5 and 100 characters")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        public string[] SelectedUsedTechnologies { get; set; }
        public string[] SelectedProgrammingLanguages { get; set; }

        [Display(Name="Used Technologies")]
        public IEnumerable<SelectListItem> UsedTechnologies { get; set; }

        [Display(Name="Programming Language")]
        public IEnumerable<SelectListItem> ProgrammingLanguages { get; set; }
         [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}