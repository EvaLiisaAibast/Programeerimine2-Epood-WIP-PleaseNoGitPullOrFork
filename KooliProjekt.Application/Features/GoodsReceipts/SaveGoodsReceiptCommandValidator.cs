using FluentValidation;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class SaveGoodsReceiptCommandValidator : AbstractValidator<SaveGoodsReceiptCommand>
    {
        public SaveGoodsReceiptCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.PurchaseOrderLineId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("PurchaseOrderLineId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.EmployeeId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("EmployeeId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);
        }
    }
}
