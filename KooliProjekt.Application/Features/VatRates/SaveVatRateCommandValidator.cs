using FluentValidation;

namespace KooliProjekt.Application.Features.VatRates
{
    public class SaveVatRateCommandValidator : AbstractValidator<SaveVatRateCommand>
    {
        public SaveVatRateCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Country)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Country on kohustuslik.")
                .MaximumLength(100).WithMessage("Country võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Rate)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(0, 100).WithMessage("Rate peab olema vahemikus 0 kuni 100.")
                .When(x => x.Data != null);
        }
    }
}
