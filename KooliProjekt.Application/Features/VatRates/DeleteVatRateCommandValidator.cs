using FluentValidation;

namespace KooliProjekt.Application.Features.VatRates
{
    public class DeleteVatRateCommandValidator : AbstractValidator<DeleteVatRateCommand>
    {
        public DeleteVatRateCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
