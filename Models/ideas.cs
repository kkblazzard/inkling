
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class Idea
    {
        [Key]
        public int IdeaId {get; set;}
        [Display(Name="Project Name:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength  (3)]
        public string name {get; set;}
        [Display(Name="Project Description:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength (3)]

        public string desc{get; set;}
        [Display(Name="Department:")] //display name for forms
        [Required] // marks it as a required field

        public List<Department> Department{get; set;}
        public List<Message> message{get; set;}
        public List<User> User{get; set;}
        public List<Results> Results{get; set;}
        public int EddId {get; set;}
        
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}