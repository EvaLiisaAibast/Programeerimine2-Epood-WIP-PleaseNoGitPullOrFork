using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.TicketMessages
{
    public class GetTicketMessageQuery : IRequest<TicketMessage>
    {
        public int Id { get; set; }
    }
}
