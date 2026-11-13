using FluentValidation;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class GetStockLevelQueryValidator : AbstractValidator<GetStockLevelQuery>
    {
        public GetStockLevelQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
