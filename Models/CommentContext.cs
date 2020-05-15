using Microsoft.EntityFrameworkCore;

namespace InformationServiceBackEnd.Models
{
    public class CommentContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasKey(c => new { c.midex, c.userid });
        }
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        { }
    }
}
