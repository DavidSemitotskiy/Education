using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation.Models
{
    public class Book
    {
        public Book(Guid id, string authors, string title, int countPages, DateTime datePublication, string format)
        {
            Authors = authors;
            Title = title;
            CountPages = countPages;
            DatePublication = datePublication;
            Format = format;
            Id = id;
        }

        public Guid Id { get; init; }

        public string? Authors { get; set; }

        public string? Title { get; set; }

        public int CountPages { get; set; }

        public DateTime DatePublication { get; set; }

        public string? Format { get; set; }

        public override string ToString()
        {
            return $"{Authors} - {Title}, {CountPages} ({DatePublication.ToString($"dd.MM.yyyy")}).{Format}";
        }
    }
}
