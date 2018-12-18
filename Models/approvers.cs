
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inkling.Models

{
    public class Approver
    {
        [Key]
        public int ApproverId {get; set;}

        public int UserId {get; set;}
        public List <User> User {get; set;}
    
        public int IdeaId {get; set;}
        
        public List <Idea> idea {get; set;}
        
        public DateTime created_at {get; set;}=DateTime.Now;
        public DateTime updated_at {get; set;}=DateTime.Now;

        
    }
}