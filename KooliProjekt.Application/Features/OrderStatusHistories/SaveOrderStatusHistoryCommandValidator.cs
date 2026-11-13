using FluentValidation;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class SaveOrderStatusHistoryCommandValidator : AbstractValidator<SaveOrderStatusHistoryCommand>
    {
        public SaveOrderStatusHistoryCommandValidator()
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

            RuleFor(x => x.Data.OldStatus)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("OldStatus on kohustuslik.")
                .MaximumLength(50).WithMessage("OldStatus võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.NewStatus)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("NewStatus on kohustuslik.")
                .MaximumLength(50).WithMessage("NewStatus võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
