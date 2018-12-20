
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Display(Name="First Name:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength  (3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string fname {get; set;}
        [Display(Name="Last Name:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength (3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string lname{get; set;}
        [Display(Name="Email:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength(7)]
        [EmailAddress] //marks it as a email data type for varification
        public string email {get; set;}
        [Display(Name="Password:")] //display name for forms
        [DataType(DataType.Password)] //marks it as a password data type for varification
        [Required] // marks it as a required field
        [MinLength (8, ErrorMessage ="Password must be 8 characters or longer!")]
    
        public string  password {get; set;}
        [Display(Name="Title:")]
        
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;
        [Display(Name="Department:")]
        public int departId {get; set;}
        public int Rank {get;set;}

        [NotMapped] //none mapped(not savedin database) entries needed for compaire validation to prevent user error
        [Display(Name="Confirm Password")]
        [Compare("password")]
        [Required] // marks it as a required field
        [DataType(DataType.Password)]
        public string confirm_password {get; set;}
        public List<Department> department {get; set;}
        public List<Message> Messages {get; set;}
        public List<Idea> Ideas {get; set;}
        public Idea Idea {get; set;}

        
    }
}