using FluentValidation;

namespace KooliProjekt.Application.Features.Payments
{
    public class SavePaymentCommandValidator : AbstractValidator<SavePaymentCommand>
    {
        public SavePaymentCommandValidator()
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

            RuleFor(x => x.Data.Amount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Amount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Method)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Method on kohustuslik.")
                .MaximumLength(50).WithMessage("Method võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.TransactionReference)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(100).WithMessage("TransactionReference võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
