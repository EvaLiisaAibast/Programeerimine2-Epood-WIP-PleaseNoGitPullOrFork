using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class ListTicketMessagesQueryHandler : IRequestHandler<ListTicketMessagesQuery, OperationResult<PagedResult<TicketMessageListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListTicketMessagesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<TicketMessageListItemDto>>> Handle(ListTicketMessagesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<TicketMessageListItemDto>>();

            response.Value = await _dbContext.TicketMessages
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new TicketMessageListItemDto
                {
                    Id = x.Id,
                    TicketSubject = _dbContext.SupportTickets.Where(t => t.Id == x.TicketId).Select(t => t.Subject).FirstOrDefault(),
                    SenderType = x.SenderType,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
