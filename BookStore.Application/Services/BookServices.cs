using BookStore.DataAccess.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Models;

namespace BookStore.Application.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBooksRepos _bookRep;
        public BookServices(IBooksRepos bookRep)
        {
            _bookRep = bookRep;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRep.Get();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookRep.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, int price, int pages)
        {
            return await _bookRep.Update(id, title, description, price, pages);
        }
        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _bookRep.Delete(id);
        }
    }
}
