using FluentValidation;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class ListStockMovementsQueryValidator : AbstractValidator<ListStockMovementsQuery>
    {
        public ListStockMovementsQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1).WithMessage("Lehekülg peab olema suurem kui 0.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Lehekülje suurus peab olema suurem kui 0.")
                .LessThanOrEqualTo(100).WithMessage("Lehekülje suurus võib olla kuni 100.");
        }
    }
}
