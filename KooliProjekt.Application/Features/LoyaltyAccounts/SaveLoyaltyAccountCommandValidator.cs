using FluentValidation;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class SaveLoyaltyAccountCommandValidator : AbstractValidator<SaveLoyaltyAccountCommand>
    {
        public SaveLoyaltyAccountCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.CustomerId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("CustomerId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Balance)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Balance ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);
        }
    }
}
