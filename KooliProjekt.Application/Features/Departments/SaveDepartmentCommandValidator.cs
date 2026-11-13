using FluentValidation;

namespace KooliProjekt.Application.Features.Departments
{
    public class SaveDepartmentCommandValidator : AbstractValidator<SaveDepartmentCommand>
    {
        public SaveDepartmentCommandValidator()
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
        }
    }
}
