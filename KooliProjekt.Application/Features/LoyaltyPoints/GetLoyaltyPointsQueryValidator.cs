using FluentValidation;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class GetLoyaltyPointsQueryValidator : AbstractValidator<GetLoyaltyPointsQuery>
    {
        public GetLoyaltyPointsQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
