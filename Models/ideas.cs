
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
        [Display(Name="Idea Name:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength  (3)]
        public string name {get; set;}
        [Display(Name="Idea Description:")] //display name for forms
        [Required] // marks it as a required field
        [MinLength (3)]

        public string desc {get; set;}
        [Display(Name="Department:")] //display name for forms
        [Required] // marks it as a required field
        public int ApproverId {get; set;}

        public int ApproverRank0 {get; set;}
        public string zeroAD {get; set;}
        public int ApproverRank1 {get; set;}
        public string oneAD {get; set;}
        public int ApproverRank2 {get; set;}
        public string twoAD {get; set;}
        public int ApproverRank3 {get; set;}
        public string threeAD {get; set;}
        public int ApproverRank4{get; set;}
        public string fourAD {get; set;}
        public int ApproverRank5 {get; set;}
        public string fiveAD {get; set;}
        public int CreatorId {get; set;}
        public List<Department> Departments{get; set;}
        public List<Message> Messages{get; set;}


        public List<Experiment> Experiments{get; set;}
        
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}