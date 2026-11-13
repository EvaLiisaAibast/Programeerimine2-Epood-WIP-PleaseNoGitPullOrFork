using FluentValidation;

namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class GetShoppingCartQueryValidator : AbstractValidator<GetShoppingCartQuery>
    {
        public GetShoppingCartQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
