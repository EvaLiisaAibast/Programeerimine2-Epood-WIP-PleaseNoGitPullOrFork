using FluentValidation;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class GetVariantOptionQueryValidator : AbstractValidator<GetVariantOptionQuery>
    {
        public GetVariantOptionQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
