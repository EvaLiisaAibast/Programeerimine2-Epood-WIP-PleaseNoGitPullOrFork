using FluentValidation;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class GetProductVariantQueryValidator : AbstractValidator<GetProductVariantQuery>
    {
        public GetProductVariantQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
