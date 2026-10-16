using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.SupportTickets
{
    public class GetSupportTicketQuery : IRequest<SupportTicket>
    {
        public int Id { get; set; }
    }
}
