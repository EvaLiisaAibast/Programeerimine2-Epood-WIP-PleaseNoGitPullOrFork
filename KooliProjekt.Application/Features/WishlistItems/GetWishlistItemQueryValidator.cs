using FluentValidation;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class GetWishlistItemQueryValidator : AbstractValidator<GetWishlistItemQuery>
    {
        public GetWishlistItemQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
