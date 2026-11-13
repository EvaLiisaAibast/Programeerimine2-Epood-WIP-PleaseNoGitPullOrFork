using FluentValidation;

namespace KooliProjekt.Application.Features.Currencies
{
    public class GetCurrencyQueryValidator : AbstractValidator<GetCurrencyQuery>
    {
        public GetCurrencyQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
