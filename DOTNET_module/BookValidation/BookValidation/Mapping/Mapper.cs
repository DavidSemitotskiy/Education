using BookValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation.Mapping
{
    public static class Mapper
    {
        public static EncryptedBook ToEncryptedBook(this Book book)
        {
            return new EncryptDecrypt().EncryptBook(book);
        }

        public static Book ToBook(this EncryptedBook encryptedBook)
        {
            return new EncryptDecrypt().DecryptBook(encryptedBook);
        }
    }
}
