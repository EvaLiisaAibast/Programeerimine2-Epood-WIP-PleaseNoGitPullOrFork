using FluentValidation;

namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class DeleteShoppingCartCommandValidator : AbstractValidator<DeleteShoppingCartCommand>
    {
        public DeleteShoppingCartCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
