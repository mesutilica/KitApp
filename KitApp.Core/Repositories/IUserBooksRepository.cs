using KitApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KitApp.Core.Repositories
{
    public interface IUserBooksRepository : IRepository<UserBooks>
    {
        Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync();
        Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync(Expression<Func<UserBooks, bool>> predicate);
    }
}
