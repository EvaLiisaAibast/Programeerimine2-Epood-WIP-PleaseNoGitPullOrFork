using FluentValidation;

namespace KooliProjekt.Application.Features.Categories
{
    public class SaveCategoryCommandValidator : AbstractValidator<SaveCategoryCommand>
    {
        public SaveCategoryCommandValidator()
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

            RuleFor(x => x.Data.Description)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(1000).WithMessage("Description võib olla kuni 1000 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
