using KitApp.Core.Repositories;
using System.Threading.Tasks;

namespace KitApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAppUserRepository user { get; }
        IBookRepository book { get; }
        Task CommitAsync();
        void Commit();
    }
}
