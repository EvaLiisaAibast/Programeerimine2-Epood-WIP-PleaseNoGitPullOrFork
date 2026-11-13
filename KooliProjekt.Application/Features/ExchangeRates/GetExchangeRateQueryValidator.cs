using FluentValidation;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class GetExchangeRateQueryValidator : AbstractValidator<GetExchangeRateQuery>
    {
        public GetExchangeRateQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
