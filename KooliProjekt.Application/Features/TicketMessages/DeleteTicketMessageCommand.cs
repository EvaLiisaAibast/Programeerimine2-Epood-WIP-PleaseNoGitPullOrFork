using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class DeleteTicketMessageCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
