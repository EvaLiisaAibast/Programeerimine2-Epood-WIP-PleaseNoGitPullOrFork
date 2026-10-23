using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class ListSupportTicketsQueryHandler : IRequestHandler<ListSupportTicketsQuery, OperationResult<PagedResult<SupportTicketListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListSupportTicketsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<SupportTicketListItemDto>>> Handle(ListSupportTicketsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<SupportTicketListItemDto>>();

            response.Value = await _dbContext.SupportTickets
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new SupportTicketListItemDto
                {
                    Id = x.Id,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Subject = x.Subject,
                    Priority = x.Priority,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
