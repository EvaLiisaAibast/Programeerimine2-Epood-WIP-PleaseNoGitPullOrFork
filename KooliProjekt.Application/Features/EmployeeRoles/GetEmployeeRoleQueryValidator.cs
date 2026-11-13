using FluentValidation;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class GetEmployeeRoleQueryValidator : AbstractValidator<GetEmployeeRoleQuery>
    {
        public GetEmployeeRoleQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
