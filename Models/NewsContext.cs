using Microsoft.EntityFrameworkCore;

namespace InformationServiceBackEnd.Models
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasKey(c => new { c.Id , c.Museum }); ;
        }

        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        { }
    }
}