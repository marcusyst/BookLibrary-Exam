using BookLibrary.Services.Models;
using FluentValidation;

namespace BookLibrary.Services.Validators
{
    public class LoanValidator : AbstractValidator<LoanModel>
    {
        public LoanValidator()
        {
            RuleFor(t => t.SubscriberId).NotNull().WithMessage("Should not be null");
        }
    }
}
