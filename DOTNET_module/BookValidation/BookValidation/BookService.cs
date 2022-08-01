using BookValidation.Interfaces;
using BookValidation.Mapping;
using BookValidation.Models;
using BookValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public FluentValidation.Results.ValidationResult AddBook(string authors, string title, int countPages, DateTime datePublication, string format)
        {
            Book book = new Book(Guid.NewGuid(), authors, title, countPages, datePublication, format);
            BookValidator validator = new BookValidator();
            var resultValidation = validator.Validate(book);
            if (resultValidation.IsValid)
            {
                _bookRepository.SaveEncryptBook(book.ToEncryptedBook());
            }

            return resultValidation;
        }

        public IEnumerable<Book> BooksInRange(DateTime x, DateTime y)
        {
            var books = _bookRepository.GetAllBooks();
            return books.Where(book => book.DatePublication < y && book.DatePublication >= x);
        }

        public IEnumerable<string> GetAllAuthors()
        {
            var books = _bookRepository.GetAllBooks().ToList();
            return books.Select(book => book.Authors).Distinct().OrderBy(author => author);
        }

        public IOrderedEnumerable<IGrouping<string, Book>> GroupBooksByAuthorsPublishedAfterCertainDate(DateTime time)
        {
            var orderedBooks = _bookRepository.GetAllBooks().Where(book => book.DatePublication > time)
                .OrderBy(book => book.Title);

            var groupBooks = from book in orderedBooks
                             group book by book.Authors;

            return groupBooks.OrderByDescending(group => group.Key);
        }

        public Book LastPublishedBook()
        {
            var books = _bookRepository.GetAllBooks();
            return books.Max(new BookComparerByTime());
        }

        public Book SearchBook(string title)
        {
            var books = _bookRepository.GetAllBooks();
            foreach (var book in books)
            {
                if (title.Equals(book.Title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }

            return null;
        }
    }
}
