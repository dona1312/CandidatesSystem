using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITSystem.ViewModels.Candidates
{
    public class CandidateEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please input first name! It is required!")]
        [StringLength(70, MinimumLength=3, ErrorMessage= "First name must contain between 3 and 70 letters")]
        [RegularExpression(@"^([A-z -])+$", ErrorMessage= "First name can consist only letters, spaces and dashes")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please input middle name! It is required!")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Middle name must contain between 3 and 70 letters")]
        [RegularExpression(@"^([A-z -])+$", ErrorMessage = "Middle name can consist only letters, spaces and dashes")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please input last name! It is required!")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Last name must contain between 3 and 70 letters")]
        [RegularExpression(@"^([A-z -])+$", ErrorMessage = "Last name can consist only letters, spaces and dashes")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please input email!It is required!")]
        [StringLength(100, MinimumLength=5, ErrorMessage = "Email nust contain between 5 and 100 characters")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        public List<Skill> Skills { get; set; }
        public List<Note> Notes { get; set; }
    }
}