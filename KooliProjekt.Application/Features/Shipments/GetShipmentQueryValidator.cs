using FluentValidation;

namespace KooliProjekt.Application.Features.Shipments
{
    public class GetShipmentQueryValidator : AbstractValidator<GetShipmentQuery>
    {
        public GetShipmentQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
