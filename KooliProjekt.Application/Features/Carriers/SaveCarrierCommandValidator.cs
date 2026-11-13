using FluentValidation;

namespace KooliProjekt.Application.Features.Carriers
{
    public class SaveCarrierCommandValidator : AbstractValidator<SaveCarrierCommand>
    {
        public SaveCarrierCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name on kohustuslik.")
                .MaximumLength(100).WithMessage("Name võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Website)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(255).WithMessage("Website võib olla kuni 255 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
