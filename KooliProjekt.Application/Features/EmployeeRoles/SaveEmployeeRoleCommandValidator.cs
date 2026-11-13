using FluentValidation;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class SaveEmployeeRoleCommandValidator : AbstractValidator<SaveEmployeeRoleCommand>
    {
        public SaveEmployeeRoleCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.EmployeeId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("EmployeeId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Role)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Role on kohustuslik.")
                .MaximumLength(50).WithMessage("Role võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
