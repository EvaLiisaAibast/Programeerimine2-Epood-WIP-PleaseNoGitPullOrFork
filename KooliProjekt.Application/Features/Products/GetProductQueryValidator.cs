using FluentValidation;

namespace KooliProjekt.Application.Features.Products
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
