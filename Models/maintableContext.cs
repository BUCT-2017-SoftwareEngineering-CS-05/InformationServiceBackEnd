using Microsoft.EntityFrameworkCore;

namespace InformationServiceBackEnd.Models
{
    public class maintableContext : DbContext
    {
        public DbSet<maintable> maintable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<maintable>().HasKey(c => c.midex); ;
        }

        public maintableContext(DbContextOptions<maintableContext> options) : base(options)
        { }
    }
}

