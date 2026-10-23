using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class ListReturnRequestsQueryHandler : IRequestHandler<ListReturnRequestsQuery, OperationResult<PagedResult<ReturnRequestListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReturnRequestsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ReturnRequestListItemDto>>> Handle(ListReturnRequestsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ReturnRequestListItemDto>>();

            response.Value = await _dbContext.ReturnRequests
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ReturnRequestListItemDto
                {
                    Id = x.Id,
                    OrderNumber = _dbContext.Orders.Where(t => t.Id == x.OrderId).Select(t => t.OrderNumber).FirstOrDefault(),
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
