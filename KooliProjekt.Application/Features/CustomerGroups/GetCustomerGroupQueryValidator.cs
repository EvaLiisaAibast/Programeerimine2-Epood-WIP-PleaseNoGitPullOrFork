using FluentValidation;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class GetCustomerGroupQueryValidator : AbstractValidator<GetCustomerGroupQuery>
    {
        public GetCustomerGroupQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
