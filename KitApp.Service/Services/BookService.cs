using KitApp.Core.Repositories;
using KitApp.Core.Services;
using KitApp.Core.UnitOfWorks;
using KitApp.Core.Entities;

namespace KitApp.Service.Services
{
    public class BookService : Service<Book>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork, IRepository<Book> repository) : base(unitOfWork, repository)
        {

        }
    }
}
