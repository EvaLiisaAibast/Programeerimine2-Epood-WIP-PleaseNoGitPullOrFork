using FluentValidation;

namespace KooliProjekt.Application.Features.Orders
{
    public class SaveOrderCommandValidator : AbstractValidator<SaveOrderCommand>
    {
        public SaveOrderCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.CustomerId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("CustomerId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.InvoiceAddressId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("InvoiceAddressId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.DeliveryAddressId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("DeliveryAddressId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Subtotal)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Subtotal ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Discount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Discount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Vat)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Vat ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ShippingCost)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("ShippingCost ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Amount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Amount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
