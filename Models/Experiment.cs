
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class Experiment
    {
        [Key]
        public int ExperimentId {get; set;}
        [Display(Name="Description")] 
        [Required]
        [MinLength  (3)]
        public string ExperimentDesc {get; set;}

        [Display(Name="Result Link")] 
        public string Result {get; set;}
        [Display(Name="Score Range 0-10")] 
        public int Score {get; set;}
        public int IdeaId {get; set;} 
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}