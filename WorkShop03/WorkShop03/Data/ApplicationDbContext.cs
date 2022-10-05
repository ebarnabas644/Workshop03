using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkShop03.Models;

namespace WorkShop03.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Advertisement>()
                .HasMany(x => x.Subscribed)
                .WithMany(x => x.Subscribed);

            base.OnModelCreating(builder);
        }
    }
}