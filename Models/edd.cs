
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class Edd
    {
        [Key]
        public int EddId {get; set;}
        [Display(Name="Message:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength  (3)]
        public string Eddlink {get; set;}
        
        public List <Results> Result {get; set;}
        
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}