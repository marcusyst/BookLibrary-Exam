using BookLibrary.Services.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Validators
{
    public class SubscriberValidator: AbstractValidator<SubscriberModel>
    {
        public SubscriberValidator()
        {
            RuleFor(t => t.CountryId).NotNull().WithMessage("Should not be null");
        }
    }
}
