using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class SaveSupportTicketCommand : IRequest<OperationResult<int>>
    {
        public SupportTicketDto Data { get; set; }
    }
}
