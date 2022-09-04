using KitApp.Core.Repositories;
using KitApp.Core.UnitOfWorks;
using KitApp.Data.Repositories;
using System.Threading.Tasks;

namespace KitApp.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private AppUserRepository _appUserRepository;
        private BookRepository _bookRepository;
        private UserBooksRepository _userBooksRepository;

        public IAppUserRepository user => _appUserRepository ??= new AppUserRepository(_context);
        public IBookRepository book => _bookRepository ??= new BookRepository(_context);
        public IUserBooksRepository userbook => _userBooksRepository ??= new UserBooksRepository(_context);

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
