
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class Department
    {
        [Key]
        public int DepartmentId {get; set;}
        [Display(Name="Department Name:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength  (3)]
        public string name {get; set;}
        [Display(Name="Project Description:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength (3)]

        public int UserId {get; set;}
        public User User {get; set;}
        public int IdeaId {get; set;}
        public Idea Idea {get; set;}
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}