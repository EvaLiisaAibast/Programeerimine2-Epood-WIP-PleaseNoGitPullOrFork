using FluentValidation;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class DeleteEmployeeRoleCommandValidator : AbstractValidator<DeleteEmployeeRoleCommand>
    {
        public DeleteEmployeeRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
