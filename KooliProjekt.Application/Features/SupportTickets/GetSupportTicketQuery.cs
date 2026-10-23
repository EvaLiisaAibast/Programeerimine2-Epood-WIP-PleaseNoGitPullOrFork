using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class GetSupportTicketQuery : IRequest<OperationResult<SupportTicketDto>>
    {
        public int Id { get; set; }
    }
}
