using FluentValidation;

namespace KooliProjekt.Application.Features.CartItems
{
    public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
    {
        public DeleteCartItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
