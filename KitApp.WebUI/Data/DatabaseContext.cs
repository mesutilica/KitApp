using KitApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KitApp.WebUI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
