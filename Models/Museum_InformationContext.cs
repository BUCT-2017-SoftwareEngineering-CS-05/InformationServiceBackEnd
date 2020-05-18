using Microsoft.EntityFrameworkCore;

namespace InformationServiceBackEnd.Models
{
    public class Museum_InformationContext : DbContext
    {
        public DbSet<Museum_Information> Museum_Information { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Museum_Information>().HasKey(c => c.midex); ;
        }

        public Museum_InformationContext(DbContextOptions<Museum_InformationContext> options) : base(options)
        { }
    }
}

