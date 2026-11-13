using FluentValidation;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class SaveShipmentTrackingCommandValidator : AbstractValidator<SaveShipmentTrackingCommand>
    {
        public SaveShipmentTrackingCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ShipmentId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ShipmentId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Location)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("Location võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
