using Microsoft.EntityFrameworkCore;
 
namespace inkling.Models
{
    public class InklingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public InklingContext(DbContextOptions<InklingContext> options) : base(options) { }
        public DbSet<User> Users {get;set;}
    }
}
