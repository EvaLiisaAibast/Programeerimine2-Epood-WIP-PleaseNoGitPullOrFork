using FluentValidation;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class GetGiftCardQueryValidator : AbstractValidator<GetGiftCardQuery>
    {
        public GetGiftCardQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
