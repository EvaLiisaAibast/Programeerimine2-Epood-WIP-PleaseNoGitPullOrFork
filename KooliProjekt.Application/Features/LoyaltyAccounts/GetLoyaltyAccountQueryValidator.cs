using FluentValidation;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class GetLoyaltyAccountQueryValidator : AbstractValidator<GetLoyaltyAccountQuery>
    {
        public GetLoyaltyAccountQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
