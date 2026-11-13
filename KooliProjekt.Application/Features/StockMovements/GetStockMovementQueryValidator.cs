using FluentValidation;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class GetStockMovementQueryValidator : AbstractValidator<GetStockMovementQuery>
    {
        public GetStockMovementQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
