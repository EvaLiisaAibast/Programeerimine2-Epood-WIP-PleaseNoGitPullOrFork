using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Orders
{
    public class ListOrdersQueryHandler : IRequestHandler<ListOrdersQuery, OperationResult<PagedResult<OrderListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOrdersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<OrderListItemDto>>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<OrderListItemDto>>();

            response.Value = await _dbContext.Orders
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new OrderListItemDto
                {
                    Id = x.Id,
                    OrderNumber = x.OrderNumber,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    OrderDate = x.OrderDate,
                    Amount = x.Amount,
                    Status = x.Status,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
