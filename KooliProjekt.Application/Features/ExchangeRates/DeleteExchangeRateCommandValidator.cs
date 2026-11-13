using FluentValidation;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class DeleteExchangeRateCommandValidator : AbstractValidator<DeleteExchangeRateCommand>
    {
        public DeleteExchangeRateCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
