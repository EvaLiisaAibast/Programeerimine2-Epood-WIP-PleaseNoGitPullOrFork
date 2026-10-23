using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Payments
{
    public class ListPaymentsQueryHandler : IRequestHandler<ListPaymentsQuery, OperationResult<PagedResult<PaymentListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPaymentsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<PaymentListItemDto>>> Handle(ListPaymentsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<PaymentListItemDto>>();

            response.Value = await _dbContext.Payments
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new PaymentListItemDto
                {
                    Id = x.Id,
                    OrderNumber = _dbContext.Orders.Where(t => t.Id == x.OrderId).Select(t => t.OrderNumber).FirstOrDefault(),
                    Method = x.Method,
                    Status = x.Status,
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
