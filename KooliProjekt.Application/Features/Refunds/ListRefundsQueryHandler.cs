using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Refunds
{
    public class ListRefundsQueryHandler : IRequestHandler<ListRefundsQuery, OperationResult<PagedResult<RefundListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListRefundsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<RefundListItemDto>>> Handle(ListRefundsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<RefundListItemDto>>();

            response.Value = await _dbContext.Refunds
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new RefundListItemDto
                {
                    Id = x.Id,
                    PaymentId = x.PaymentId,
                    Amount = x.Amount,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
