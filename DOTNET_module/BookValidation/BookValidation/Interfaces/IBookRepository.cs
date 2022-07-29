using BookValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation.Interfaces
{
    public interface IBookRepository
    {
        void SaveEncryptBook(EncryptedBook encryptedBook);

        IEnumerable<Book> GetAllBooks();
    }
}
