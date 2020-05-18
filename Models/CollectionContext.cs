using Microsoft.EntityFrameworkCore;

namespace InformationServiceBackEnd.Models
{
    public class CollectionContext : DbContext
    {
        public DbSet<Collection> Collection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>().HasKey(c => new { c.midex ,c.oid}); ;
        }

        public CollectionContext(DbContextOptions<CollectionContext> options) : base(options)
        { }
    }
}

