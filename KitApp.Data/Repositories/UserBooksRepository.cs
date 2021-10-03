using KitApp.Core.Repositories;
using KitApp.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace KitApp.Data.Repositories
{
    public class UserBooksRepository : Repository<UserBooks>, IUserBooksRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public UserBooksRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync()
        {
            return await _appDbContext.UserBooks.Include(x => x.AppUser).Include(x => x.Book).ToListAsync();
        }

        public async Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync(Expression<Func<UserBooks, bool>> predicate)
        {
            return await _appDbContext.UserBooks.Include(x => x.AppUser).Include(x => x.Book).Where(predicate).ToListAsync();
        }
    }
}
