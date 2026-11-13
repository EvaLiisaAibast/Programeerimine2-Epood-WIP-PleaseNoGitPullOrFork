using FluentValidation;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class DeleteVariantOptionCommandValidator : AbstractValidator<DeleteVariantOptionCommand>
    {
        public DeleteVariantOptionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
