using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.TicketMessages
{
    public class ListTicketMessagesQuery : IRequest<IEnumerable<TicketMessage>>
    {
    }
}
