using FluentValidation;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class GetTicketMessageQueryValidator : AbstractValidator<GetTicketMessageQuery>
    {
        public GetTicketMessageQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
