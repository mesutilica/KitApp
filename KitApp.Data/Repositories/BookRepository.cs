using KitApp.Core.Repositories;
//using KitApp.Data.EntityFramework;
using KitApp.Core.Entities;

namespace KitApp.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
