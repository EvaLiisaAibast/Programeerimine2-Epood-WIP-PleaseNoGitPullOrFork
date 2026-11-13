using FluentValidation;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class DeleteLoyaltyPointsCommandValidator : AbstractValidator<DeleteLoyaltyPointsCommand>
    {
        public DeleteLoyaltyPointsCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
