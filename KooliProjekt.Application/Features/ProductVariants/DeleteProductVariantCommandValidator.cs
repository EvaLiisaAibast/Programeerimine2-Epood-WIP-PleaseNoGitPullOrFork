using FluentValidation;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class DeleteProductVariantCommandValidator : AbstractValidator<DeleteProductVariantCommand>
    {
        public DeleteProductVariantCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
