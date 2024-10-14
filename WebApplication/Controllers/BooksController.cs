using BookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Contracts;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookService;
        public BooksController(IBookServices bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();

            var response = books.Select(b => new BookResponse(b.Id, b.Title, b.Description, b.Pages, b.Price));
           
            return Ok(response);
        }
    }
}
