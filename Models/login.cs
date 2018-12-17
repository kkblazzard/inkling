using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models
{
    public class LoginUser
    {   
        [Display(Name="Email:")]
        [Required]
        [EmailAddress]
        
        public string Email {get; set;}
        [Display(Name="Password:")]
        [DataType(DataType.Password)]
        [Required]
        [MinLength (8, ErrorMessage ="Password must be 8 characters or longer!")]
        public string Password {get; set;}
    }
}