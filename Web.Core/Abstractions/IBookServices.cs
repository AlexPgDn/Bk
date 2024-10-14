using Web.Core.Models;

namespace BookStore.Application.Services
{
    public interface IBookServices
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, int price, int pages);
    }
}