using FluentValidation;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class SaveStockMovementCommandValidator : AbstractValidator<SaveStockMovementCommand>
    {
        public SaveStockMovementCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.StockLevelId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("StockLevelId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Type)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Type on kohustuslik.")
                .MaximumLength(50).WithMessage("Type võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Reason)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(500).WithMessage("Reason võib olla kuni 500 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
