using FluentValidation;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class SaveReturnLineCommandValidator : AbstractValidator<SaveReturnLineCommand>
    {
        public SaveReturnLineCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ReturnRequestId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ReturnRequestId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.OrderLineId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("OrderLineId ei tohi olla väiksem kui 1.")
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
