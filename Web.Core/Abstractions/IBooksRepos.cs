using Web.Core.Models;

namespace BookStore.DataAccess.Repos
{
    public interface IBooksRepos
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid id, string title, string description, int price, int pages);
    }
}