using BookLibrary.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Validators
{
    public class BookValidator: AbstractValidator<BookModel>
    {
        public BookValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Should not be empty").MinimumLength(1).MaximumLength(100);
            RuleFor(t => t.StockLevel).NotEmpty().WithMessage("Should not be empty");
        }
    }
}
