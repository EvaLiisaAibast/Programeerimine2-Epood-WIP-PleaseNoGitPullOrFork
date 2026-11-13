using FluentValidation;

namespace KooliProjekt.Application.Features.Carriers
{
    public class DeleteCarrierCommandValidator : AbstractValidator<DeleteCarrierCommand>
    {
        public DeleteCarrierCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
