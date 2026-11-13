using FluentValidation;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class DeleteOptionValueCommandValidator : AbstractValidator<DeleteOptionValueCommand>
    {
        public DeleteOptionValueCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
