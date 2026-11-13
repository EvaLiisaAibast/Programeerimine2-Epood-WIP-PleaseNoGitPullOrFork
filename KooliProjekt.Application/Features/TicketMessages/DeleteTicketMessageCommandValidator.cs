using FluentValidation;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class DeleteTicketMessageCommandValidator : AbstractValidator<DeleteTicketMessageCommand>
    {
        public DeleteTicketMessageCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
