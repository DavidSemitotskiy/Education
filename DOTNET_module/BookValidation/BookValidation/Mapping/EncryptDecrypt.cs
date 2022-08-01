using BookValidation.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation.Mapping
{
    public class EncryptDecrypt
    {
        public EncryptDecrypt()
        {
            FileInfo file = new FileInfo(@"../../../../appsettings.json");
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(file.FullName).Build();
            string KeyForEncrypt = config.GetValue<string>("Key");
            Key = Encoding.Default.GetBytes(KeyForEncrypt);
        }

        private byte[] Key { get; } 

        private byte[] IV { get; } = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public EncryptedBook EncryptBook(Book book)
        {
            return new EncryptedBook(book.Id,
                EncryptField(book.Authors, Key, IV),
                EncryptField(book.Title, Key, IV),
                book.CountPages,
                book.DatePublication,
                EncryptField(book.Format, Key, IV));
        }

        public Book DecryptBook(EncryptedBook encryptedBook)
        {
            return new Book(encryptedBook.Id, DecryptField(encryptedBook.Authors, Key, IV),
                DecryptField(encryptedBook.Title, Key, IV),
                encryptedBook.CountPages,
                encryptedBook.DatePublication,
                DecryptField(encryptedBook.Format, Key, IV));
        }

        private string EncryptField(string plainText, byte[] key, byte[] IV)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = IV;
                MemoryStream ms = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] bytes = Encoding.Default.GetBytes(plainText);
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private string DecryptField(string encryptedText, byte[] key, byte[] IV)
        {
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = IV;
                MemoryStream ms = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
                byte[] encrypted = Convert.FromBase64String(encryptedText);
                cryptoStream.Write(encrypted, 0, encrypted.Length);
                cryptoStream.FlushFinalBlock();
                byte[] decrypted = ms.ToArray();
                return UTF8Encoding.UTF8.GetString(decrypted, 0, decrypted.Length);
            }
        }
    }
}
