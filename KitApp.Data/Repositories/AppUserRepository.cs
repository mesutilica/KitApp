using KitApp.Core.Repositories;
//using KitApp.Data.EntityFramework;
using KitApp.Core.Entities;

namespace KitApp.Data.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
