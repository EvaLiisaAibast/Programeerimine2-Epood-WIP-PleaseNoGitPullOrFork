using FluentValidation;

namespace KooliProjekt.Application.Features.Brands
{
    public class GetBrandQueryValidator : AbstractValidator<GetBrandQuery>
    {
        public GetBrandQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
