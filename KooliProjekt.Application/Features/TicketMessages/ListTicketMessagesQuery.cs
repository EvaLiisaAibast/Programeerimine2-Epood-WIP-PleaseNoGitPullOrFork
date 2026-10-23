using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class ListTicketMessagesQuery : IRequest<OperationResult<PagedResult<TicketMessageListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
