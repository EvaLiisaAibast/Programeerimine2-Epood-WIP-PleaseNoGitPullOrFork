using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OrderLines
{
    public class ListOrderLinesQueryHandler : IRequestHandler<ListOrderLinesQuery, OperationResult<PagedResult<OrderLineListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOrderLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<OrderLineListItemDto>>> Handle(ListOrderLinesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<OrderLineListItemDto>>();

            response.Value = await _dbContext.OrderLines
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new OrderLineListItemDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    Amount = x.Amount,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
