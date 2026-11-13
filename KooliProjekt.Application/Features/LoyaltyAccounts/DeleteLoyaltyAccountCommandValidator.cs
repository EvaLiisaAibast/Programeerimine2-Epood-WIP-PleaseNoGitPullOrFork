using FluentValidation;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class DeleteLoyaltyAccountCommandValidator : AbstractValidator<DeleteLoyaltyAccountCommand>
    {
        public DeleteLoyaltyAccountCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
