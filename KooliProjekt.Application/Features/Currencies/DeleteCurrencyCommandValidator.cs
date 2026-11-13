using FluentValidation;

namespace KooliProjekt.Application.Features.Currencies
{
    public class DeleteCurrencyCommandValidator : AbstractValidator<DeleteCurrencyCommand>
    {
        public DeleteCurrencyCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
