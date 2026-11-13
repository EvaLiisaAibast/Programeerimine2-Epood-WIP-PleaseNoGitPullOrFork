using FluentValidation;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class DeleteSupportTicketCommandValidator : AbstractValidator<DeleteSupportTicketCommand>
    {
        public DeleteSupportTicketCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
