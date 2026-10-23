using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class GetTicketMessageQuery : IRequest<OperationResult<TicketMessageDto>>
    {
        public int Id { get; set; }
    }
}
