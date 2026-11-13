using FluentValidation;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class SaveLoyaltyPointsCommandValidator : AbstractValidator<SaveLoyaltyPointsCommand>
    {
        public SaveLoyaltyPointsCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.AccountId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("AccountId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Points)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Points ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Reason)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Reason on kohustuslik.")
                .MaximumLength(200).WithMessage("Reason võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
