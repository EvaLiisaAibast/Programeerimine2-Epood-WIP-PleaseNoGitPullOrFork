using FluentValidation;

namespace KooliProjekt.Application.Features.Employees
{
    public class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
    {
        public GetEmployeeQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
