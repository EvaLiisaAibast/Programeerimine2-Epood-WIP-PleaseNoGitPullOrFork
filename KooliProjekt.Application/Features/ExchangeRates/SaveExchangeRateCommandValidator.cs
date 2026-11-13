using FluentValidation;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class SaveExchangeRateCommandValidator : AbstractValidator<SaveExchangeRateCommand>
    {
        public SaveExchangeRateCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.FromCurrencyId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("FromCurrencyId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ToCurrencyId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ToCurrencyId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Rate)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Rate ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);
        }
    }
}
