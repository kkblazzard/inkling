using Microsoft.EntityFrameworkCore;
 
namespace inkling.Models
{
    public class InklingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public InklingContext(DbContextOptions<InklingContext> options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Department> Department {get;set;}
        public DbSet<Experiment> Experiment {get;set;}
        public DbSet<Idea> Ideas {get;set;}
        public DbSet<Message> Message  {get;set;}


    }
}
