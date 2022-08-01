using BookValidation.Interfaces;
using BookValidation.Mapping;
using BookValidation.Models;
using BookValidation.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation
{
    public class Program
    {
        public static void Main()
        {
            IBookRepository bookRepository = new BookRepository();
            IBookService bookService = new BookService(bookRepository);
            //CultureInfo.CurrentCulture = new CultureInfo("en-US");
            AddBook(bookService);
            SearchBook(bookService);
            AllAuthors(bookService);
            LastPublishedBook(bookService);
            BookInRange(bookService);
            GroupBooksByAuthorsPublishedAfterCertainDate(bookService);
        }

        public static void AddBook(IBookService bookService)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("<Автор> - <Назва>, <кількість сторінок>(<дата публікації>)<формат>");
            string information = Console.ReadLine();
            var resultValidation = new ValidateBook().IsValidInputString(information);
            if (resultValidation.Success)
            {
                DateTime date = new DateTime();
                string datePublication = resultValidation.Groups[4].Value;
                if (new ValidateDate().IsValidDate(ref datePublication))
                {
                     date = DateTime.Parse(datePublication);
                }
                else
                {
                    Console.WriteLine("Incorrect Date");
                    return;
                }
        
                var resultAdd = bookService.AddBook(resultValidation.Groups[1].Value, resultValidation.Groups[2].Value,
                    Convert.ToInt32(resultValidation.Groups[3].Value), date, resultValidation.Groups[5].Value);
                if (resultAdd.Errors.Count != 0)
                {
                    Console.WriteLine(resultAdd.ToString("\n"));
                }
            }
            else
            {
                Console.WriteLine("Incorrect format!");
            }
        }

        public static void SearchBook(IBookService bookService)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Write("Введіть назву книги: ");
                string titleOfSearchingBook = Console.ReadLine();
                if (string.IsNullOrEmpty(titleOfSearchingBook))
                {
                    Console.WriteLine("Incorrect title");
                    Console.Clear();
                    continue;
                }

                var searchingBook = bookService.SearchBook(titleOfSearchingBook);
                if (searchingBook == null)
                {
                    Console.WriteLine("There isn't such book");
                    break;
                }

                Console.WriteLine(searchingBook);
                break;
            }
        }

        public static void AllAuthors(IBookService bookService)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var authors = bookService.GetAllAuthors();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var author in authors)
            {
                stringBuilder.Append($"{author}, ");
            }

            string strAuthors = new string(stringBuilder.ToString());
            Console.WriteLine(strAuthors.TrimEnd(',', ' '));
        }

        public static void LastPublishedBook(IBookService bookService)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var lastPublishedBook = bookService.LastPublishedBook();
            if (lastPublishedBook == null)
            {
                Console.WriteLine("There aren't any books to find last published one!");
                return;
            }
            Console.WriteLine(lastPublishedBook);
        }

        public static void BookInRange(IBookService bookService)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Write("Введіть першу дату: ");
            string firstDate = Console.ReadLine();
            Console.Write("Введіть другу дату: ");
            string secondDate = Console.ReadLine();
            DateTime x = new DateTime();
            DateTime y = new DateTime();
            ValidateDate validate = new ValidateDate();
            if (validate.IsValidDate(ref firstDate) && validate.IsValidDate(ref secondDate))
            {
                x = DateTime.Parse(firstDate);
                y = DateTime.Parse(secondDate);
            }
            else
            {
                Console.WriteLine("Incorrect Date");
                return;
            }

            var resultFiltering = bookService.BooksInRange(x, y).ToList();
            if (resultFiltering.Count == 0 || resultFiltering == null)
            {
                Console.WriteLine("No books for this time range");
                return;
            }

            int countElementsOnPage = 2;
            int countPages = resultFiltering.Count % 2 != 0
                ? resultFiltering.Count / countElementsOnPage + 1 : resultFiltering.Count / countElementsOnPage;
            for (int page = 0; page != countPages; page++)
            {
                Console.WriteLine($"Page: #{page + 1}");
                foreach (var book in resultFiltering.Skip(page * countElementsOnPage).Take(countElementsOnPage))
                {
                    Console.WriteLine(book);
                }
            }
        }

        public static void GroupBooksByAuthorsPublishedAfterCertainDate(IBookService bookService)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Write("Введіть дату: ");
            string date = Console.ReadLine();
            DateTime dateTime = new DateTime();
            if (new ValidateDate().IsValidDate(ref date))
            {
                dateTime = DateTime.Parse(date);
            }
            else
            {
                Console.WriteLine("Incorrect Date");
                return;
            }

            var resultGrouping = bookService.GroupBooksByAuthorsPublishedAfterCertainDate(dateTime).ToList();
            int countGroupsOnPage = 1;
            int countPages = resultGrouping.Count;
            for (int page = 0; page != countPages; page++)
            {
                Console.WriteLine($"Page: #{page + 1}");
                foreach (var group in resultGrouping.Skip(page * countGroupsOnPage).Take(countGroupsOnPage))
                {
                    Console.WriteLine($"Group: {group.Key}");
                    foreach (var book in group)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
        }
    }
}
