using Microsoft.EntityFrameworkCore;

namespace InformationServiceBackEnd.Models
{
    public class EducationContext : DbContext
    {
        public DbSet<Education> Education { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().HasKey(c => new { c.midex, c.aid }); ;
        }

        public EducationContext(DbContextOptions<EducationContext> options) : base(options)
        { }
    }
}
