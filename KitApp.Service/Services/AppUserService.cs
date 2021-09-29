using KitApp.Core.Repositories;
using KitApp.Core.Services;
using KitApp.Core.UnitOfWorks;
using KitApp.Core.Entities;

namespace KitApp.Service.Services
{
    public class AppUserService : Service<AppUser>, IAppUserService
    {
        public AppUserService(IUnitOfWork unitOfWork, IRepository<AppUser> repository) : base(unitOfWork, repository)
        {
        }
    }
}
