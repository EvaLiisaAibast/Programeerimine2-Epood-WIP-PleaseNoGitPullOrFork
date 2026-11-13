using FluentValidation;

namespace KooliProjekt.Application.Features.Employees
{
    public class SaveEmployeeCommandValidator : AbstractValidator<SaveEmployeeCommand>
    {
        public SaveEmployeeCommandValidator()
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

            RuleFor(x => x.Data.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email on kohustuslik.")
                .MaximumLength(100).WithMessage("Email võib olla kuni 100 tähemärki.")
                .EmailAddress().WithMessage("Email peab olema korrektne e-posti aadress.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.DepartmentId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("DepartmentId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);
        }
    }
}
