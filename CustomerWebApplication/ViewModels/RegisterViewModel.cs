using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebApplication.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }

        [Required]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
