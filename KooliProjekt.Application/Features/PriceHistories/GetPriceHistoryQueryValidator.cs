using FluentValidation;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class GetPriceHistoryQueryValidator : AbstractValidator<GetPriceHistoryQuery>
    {
        public GetPriceHistoryQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
