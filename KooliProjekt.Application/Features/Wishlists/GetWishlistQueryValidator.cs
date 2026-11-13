using FluentValidation;

namespace KooliProjekt.Application.Features.Wishlists
{
    public class GetWishlistQueryValidator : AbstractValidator<GetWishlistQuery>
    {
        public GetWishlistQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
