using BookValidation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Authors).Length(1, 50).NotNull().NotEmpty();
            RuleFor(book => book.Title).Length(1, 100).NotNull().NotEmpty();
            RuleFor(book => book.Format).NotNull().NotEmpty();
        }
    }
}
