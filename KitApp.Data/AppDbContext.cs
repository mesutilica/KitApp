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
        public DbSet<UserBooks> UserBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            //Login kullanıcısı
            modelBuilder.Entity<AppUser>().
                HasData(new AppUser
                {
                    Id = 1,
                    UserName = "demouser",
                    Password = "demouser1",
                    Email = "demo@user.com",
                    Name = "demo",
                    SurName = "test",
                    Phone = "0216",
                    CreateDate = System.DateTime.Now,
                    IsActive = true
                });
            //base.OnModelCreating(modelBuilder);
        }
    }
}
