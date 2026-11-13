using FluentValidation;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetProductImageQueryValidator : AbstractValidator<GetProductImageQuery>
    {
        public GetProductImageQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
