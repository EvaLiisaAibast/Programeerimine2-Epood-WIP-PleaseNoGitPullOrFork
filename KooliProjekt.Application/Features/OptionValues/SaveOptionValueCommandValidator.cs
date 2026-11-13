using FluentValidation;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class SaveOptionValueCommandValidator : AbstractValidator<SaveOptionValueCommand>
    {
        public SaveOptionValueCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ProductOptionId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ProductOptionId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Value)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Value on kohustuslik.")
                .MaximumLength(100).WithMessage("Value võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
