using FluentValidation;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class DeletePriceHistoryCommandValidator : AbstractValidator<DeletePriceHistoryCommand>
    {
        public DeletePriceHistoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
