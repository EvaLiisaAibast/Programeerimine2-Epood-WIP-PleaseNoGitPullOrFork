using FluentValidation;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class DeleteCustomerGroupCommandValidator : AbstractValidator<DeleteCustomerGroupCommand>
    {
        public DeleteCustomerGroupCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
