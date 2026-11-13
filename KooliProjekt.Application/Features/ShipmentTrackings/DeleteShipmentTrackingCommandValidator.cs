using FluentValidation;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class DeleteShipmentTrackingCommandValidator : AbstractValidator<DeleteShipmentTrackingCommand>
    {
        public DeleteShipmentTrackingCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
