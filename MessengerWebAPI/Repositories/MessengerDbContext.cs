using MessengerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MessengerWebApi.Repositories
{
    public class MessengerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public MessengerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auth>(entity =>
            {
                entity.HasOne(a => a.User)
                .WithOne(u => u.Auth)
                .HasForeignKey<Auth>(a => a.UserId)
                .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
