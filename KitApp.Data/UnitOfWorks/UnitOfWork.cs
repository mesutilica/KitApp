using KitApp.Core.Repositories;
using KitApp.Core.UnitOfWorks;
//using KitApp.Data.EntityFramework;
using KitApp.Data.Repositories;
using System.Threading.Tasks;

namespace KitApp.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private AppUserRepository _appUserRepository;
        private BookRepository _bookRepository;

        public IAppUserRepository user => _appUserRepository = _appUserRepository ?? new AppUserRepository(_context);
        public IBookRepository book => _bookRepository = _bookRepository ?? new BookRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
