using FluentValidation;

namespace KooliProjekt.Application.Features.OrderLines
{
    public class SaveOrderLineCommandValidator : AbstractValidator<SaveOrderLineCommand>
    {
        public SaveOrderLineCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.OrderId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("OrderId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ProductId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ProductId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ProductName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("ProductName on kohustuslik.")
                .MaximumLength(200).WithMessage("ProductName võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.VariantId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("VariantId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.VariantCode)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(50).WithMessage("VariantCode võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.UnitPrice)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("UnitPrice ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Discount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Discount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Amount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Amount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);
        }
    }
}
