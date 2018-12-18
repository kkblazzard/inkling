
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class Results
    {
        [Key]
        public int ResultId {get; set;}
        [Display(Name="Message:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength  (3)]
        public string result {get; set;}
        public Edd EddId {get; set;}
        public string extra {get; set;}
        public string extra2 {get; set;}
        
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}