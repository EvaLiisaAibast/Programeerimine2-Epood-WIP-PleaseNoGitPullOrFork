using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.SupportTickets
{
    public class ListSupportTicketsQuery : IRequest<IEnumerable<SupportTicket>>
    {
    }
}
