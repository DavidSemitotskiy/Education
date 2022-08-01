using BookValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation
{
    public class BookComparerByTime : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            return x.DatePublication.CompareTo(y.DatePublication);
        }
    }
}
