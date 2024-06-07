using Microsoft.EntityFrameworkCore;

namespace FlashcardWebApp.LeaderboardAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<Attempt> Attempt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attempt>().HasKey(E => new { E.No, E.SetName });
        }
    }
}
