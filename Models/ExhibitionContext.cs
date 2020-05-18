using Microsoft.EntityFrameworkCore;

namespace InformationServiceBackEnd.Models
{
    public class ExhibitionContext : DbContext
    {
        public DbSet<Exhibition> Exhibition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exhibition>().HasKey(c => new { c.midex, c.eid }); ;
        }

        public ExhibitionContext(DbContextOptions<ExhibitionContext> options) : base(options)
        { }
    }
}

