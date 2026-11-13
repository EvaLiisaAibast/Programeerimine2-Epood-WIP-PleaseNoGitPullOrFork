using FluentValidation;

namespace KooliProjekt.Application.Features.Departments
{
    public class GetDepartmentQueryValidator : AbstractValidator<GetDepartmentQuery>
    {
        public GetDepartmentQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
