using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class DeleteSupportTicketCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
