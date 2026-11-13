using FluentValidation;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class DeleteStockMovementCommandValidator : AbstractValidator<DeleteStockMovementCommand>
    {
        public DeleteStockMovementCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
