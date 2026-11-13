using FluentValidation;

namespace KooliProjekt.Application.Features.OrderLines
{
    public class DeleteOrderLineCommandValidator : AbstractValidator<DeleteOrderLineCommand>
    {
        public DeleteOrderLineCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
