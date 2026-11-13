using FluentValidation;

namespace KooliProjekt.Application.Features.CartItems
{
    public class GetCartItemQueryValidator : AbstractValidator<GetCartItemQuery>
    {
        public GetCartItemQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
