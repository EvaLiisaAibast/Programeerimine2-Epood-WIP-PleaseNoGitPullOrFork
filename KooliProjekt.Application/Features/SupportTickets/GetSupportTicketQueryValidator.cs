using FluentValidation;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class GetSupportTicketQueryValidator : AbstractValidator<GetSupportTicketQuery>
    {
        public GetSupportTicketQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
