using FluentValidation;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class GetShipmentTrackingQueryValidator : AbstractValidator<GetShipmentTrackingQuery>
    {
        public GetShipmentTrackingQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
