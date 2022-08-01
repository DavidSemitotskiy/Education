using BookValidation.Interfaces;
using BookValidation.Mapping;
using BookValidation.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAllBooks()
        {
            using (StreamReader file = new StreamReader("BookStorage.json"))
            {
                string serializeObject = null;
                while (file.Peek() != -1)
                {
                    serializeObject = file.ReadLine();
                    yield return JsonConvert.DeserializeObject<EncryptedBook>(serializeObject).ToBook();
                }

                file.Close();
            }
        }

        public void SaveEncryptBook(EncryptedBook encryptedBook)
        {
            var serializeBook = JsonConvert.SerializeObject(encryptedBook, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            using (StreamWriter file = new StreamWriter("BookStorage.json", true))
            {
                file.WriteLine(serializeBook);
                file.Close();
            }
        }
    }
}
