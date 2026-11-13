using FluentValidation;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class SaveReturnRequestCommandValidator : AbstractValidator<SaveReturnRequestCommand>
    {
        public SaveReturnRequestCommandValidator()
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

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Reason)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(500).WithMessage("Reason võib olla kuni 500 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
