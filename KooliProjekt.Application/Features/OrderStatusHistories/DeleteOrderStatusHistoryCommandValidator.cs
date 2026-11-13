using FluentValidation;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class DeleteOrderStatusHistoryCommandValidator : AbstractValidator<DeleteOrderStatusHistoryCommand>
    {
        public DeleteOrderStatusHistoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
