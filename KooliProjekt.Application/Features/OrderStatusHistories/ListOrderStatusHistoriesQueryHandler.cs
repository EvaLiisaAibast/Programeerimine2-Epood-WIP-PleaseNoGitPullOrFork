using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class ListOrderStatusHistoriesQueryHandler : IRequestHandler<ListOrderStatusHistoriesQuery, OperationResult<PagedResult<OrderStatusHistoryListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOrderStatusHistoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<OrderStatusHistoryListItemDto>>> Handle(ListOrderStatusHistoriesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<OrderStatusHistoryListItemDto>>();

            response.Value = await _dbContext.OrderStatusHistories
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new OrderStatusHistoryListItemDto
                {
                    Id = x.Id,
                    OrderNumber = _dbContext.Orders.Where(t => t.Id == x.OrderId).Select(t => t.OrderNumber).FirstOrDefault(),
                    OldStatus = x.OldStatus,
                    NewStatus = x.NewStatus,
                    ModifiedAt = x.ModifiedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
