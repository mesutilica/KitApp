using KitApp.Data.Configurations;
using KitApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KitApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
