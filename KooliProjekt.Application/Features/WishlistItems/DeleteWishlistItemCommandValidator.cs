using FluentValidation;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class DeleteWishlistItemCommandValidator : AbstractValidator<DeleteWishlistItemCommand>
    {
        public DeleteWishlistItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
