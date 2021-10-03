using KitApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KitApp.Core.Services
{
    public interface IUserBooksService : IService<UserBooks>
    {
        Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync();
        Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync(Expression<Func<UserBooks, bool>> predicate);
    }
}
