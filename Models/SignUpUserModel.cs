using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your first name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]

        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter your email")]
        [Display(Name ="Email Address" )]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

    }
}
