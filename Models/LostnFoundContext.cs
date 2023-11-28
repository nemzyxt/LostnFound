using Microsoft.EntityFrameworkCore;

namespace LostnFound.Models
{
    public class LostnFoundContext : DbContext
    {
        public LostnFoundContext(DbContextOptions<LostnFoundContext> options) : base(options)
        {
        }

        // DbSet properties represent database tables
        public DbSet<AuthModel> Auth { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthModel>().HasKey(e => e.UserId);
            modelBuilder.Entity<LostItemModel>().HasKey(e => e.ItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
