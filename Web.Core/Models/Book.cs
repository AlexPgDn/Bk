using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;
        private Book(Guid Id, string Title, string Description, int Price, int Pages)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Price = Price;
            this.Pages = Pages;
        }
        public Guid Id { get; }
        public string Title { get;  } = string.Empty;
        public string Description { get; } = string.Empty ;
        public int Price { get; }
        public int Pages { get; }

        public static (Book Book, string Error) Create(Guid id, string title, string description, int price, int pages)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(error) || title.Length > MAX_TITLE_LENGTH )
            {
                error = "Title cannot be empty or longer than 250 symb.";
            }
            var book = new Book(id, title, description, price, pages);

            return (book,error);
        }

    }
}
