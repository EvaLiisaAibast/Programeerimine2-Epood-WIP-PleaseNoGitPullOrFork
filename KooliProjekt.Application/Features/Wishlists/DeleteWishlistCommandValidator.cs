using FluentValidation;

namespace KooliProjekt.Application.Features.Wishlists
{
    public class DeleteWishlistCommandValidator : AbstractValidator<DeleteWishlistCommand>
    {
        public DeleteWishlistCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
