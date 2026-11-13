using FluentValidation;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class GetProductOptionQueryValidator : AbstractValidator<GetProductOptionQuery>
    {
        public GetProductOptionQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
