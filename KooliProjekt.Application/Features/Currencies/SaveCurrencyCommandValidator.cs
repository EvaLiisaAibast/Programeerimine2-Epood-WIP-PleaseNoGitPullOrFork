using FluentValidation;

namespace KooliProjekt.Application.Features.Currencies
{
    public class SaveCurrencyCommandValidator : AbstractValidator<SaveCurrencyCommand>
    {
        public SaveCurrencyCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Code on kohustuslik.")
                .MaximumLength(10).WithMessage("Code võib olla kuni 10 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name on kohustuslik.")
                .MaximumLength(100).WithMessage("Name võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Symbol)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Symbol on kohustuslik.")
                .MaximumLength(10).WithMessage("Symbol võib olla kuni 10 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
