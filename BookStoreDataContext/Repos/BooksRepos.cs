using BookStore.DataAccess.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Models;

namespace BookStore.DataAccess.Repos
{
    public class BooksRepos : IBooksRepos
    {
        private readonly BookStoreDbContext _context;

        public BooksRepos(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price, b.Pages).Book)
                .ToList();
            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Pages = book.Pages
            };
            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }
        public async Task<Guid> Update(Guid id, string title, string description, int price, int pages)
        {
            await _context.Books
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price)
                    .SetProperty(b => b.Pages, b => pages)
                );
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {

            await _context.Books
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
