using FluentValidation;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class SavePriceHistoryCommandValidator : AbstractValidator<SavePriceHistoryCommand>
    {
        public SavePriceHistoryCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.VariantId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("VariantId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.CurrentPrice)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("CurrentPrice ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);
        }
    }
}
