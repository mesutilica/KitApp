using KitApp.Core.Repositories;
using KitApp.Core.Services;
using KitApp.Core.UnitOfWorks;
using KitApp.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace KitApp.Service.Services
{
    public class UserBooksService : Service<UserBooks>, IUserBooksService
    {
        public UserBooksService(IUnitOfWork unitOfWork, IRepository<UserBooks> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync()
        {
            return await _unitOfWork.userbook.GetAllBooksByUsersAsync();
        }

        public async Task<IEnumerable<UserBooks>> GetAllBooksByUsersAsync(Expression<Func<UserBooks, bool>> predicate)
        {
            return await _unitOfWork.userbook.GetAllBooksByUsersAsync(predicate);
        }
    }
}
