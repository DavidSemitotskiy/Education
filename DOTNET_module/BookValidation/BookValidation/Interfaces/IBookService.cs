using BookValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation.Interfaces
{
    public interface IBookService
    {
        FluentValidation.Results.ValidationResult AddBook(string authors, string title, int countPages, DateTime datePublication, string format);

        Book LastPublishedBook();

        IEnumerable<Book> BooksInRange(DateTime x, DateTime y);

        IOrderedEnumerable<IGrouping<string, Book>> GroupBooksByAuthorsPublishedAfterCertainDate(DateTime time);

        Book SearchBook(string title);

        IEnumerable<string> GetAllAuthors();
    }
}
