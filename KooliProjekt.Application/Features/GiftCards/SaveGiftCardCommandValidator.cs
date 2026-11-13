using FluentValidation;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class SaveGiftCardCommandValidator : AbstractValidator<SaveGiftCardCommand>
    {
        public SaveGiftCardCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Code on kohustuslik.")
                .MaximumLength(50).WithMessage("Code võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.InitialAmount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("InitialAmount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Balance)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Balance ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);
        }
    }
}
