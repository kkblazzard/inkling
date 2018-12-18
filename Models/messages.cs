
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class Message
    {
        [Key]
        public int MessageId {get; set;}
        [Display(Name="Message:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength  (3)]
        public string message {get; set;}
    
        [Required] // marks it as a required field
        public int UserId {get; set;}
        
        public List <Idea> idea {get; set;}
        
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}