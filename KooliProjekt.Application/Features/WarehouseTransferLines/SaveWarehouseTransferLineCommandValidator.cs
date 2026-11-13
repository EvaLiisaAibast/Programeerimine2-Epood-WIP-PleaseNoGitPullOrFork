using FluentValidation;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class SaveWarehouseTransferLineCommandValidator : AbstractValidator<SaveWarehouseTransferLineCommand>
    {
        public SaveWarehouseTransferLineCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.TransferId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("TransferId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.VariantId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("VariantId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);
        }
    }
}
