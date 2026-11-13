using FluentValidation;

namespace KooliProjekt.Application.Features.Shipments
{
    public class DeleteShipmentCommandValidator : AbstractValidator<DeleteShipmentCommand>
    {
        public DeleteShipmentCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
