using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class GetOrderStatusHistoryQueryHandler : IRequestHandler<GetOrderStatusHistoryQuery, OperationResult<OrderStatusHistoryDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrderStatusHistoryQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OrderStatusHistoryDto>> Handle(GetOrderStatusHistoryQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<OrderStatusHistoryDto>();

            response.Value = await _dbContext.OrderStatusHistories
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new OrderStatusHistoryDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    OrderNumber = _dbContext.Orders.Where(t => t.Id == x.OrderId).Select(t => t.OrderNumber).FirstOrDefault(),
                    OldStatus = x.OldStatus,
                    NewStatus = x.NewStatus,
                    ModifiedAt = x.ModifiedAt,
                    ChangedBy = x.ChangedBy,
                    ChangedByName = _dbContext.Employees.Where(t => t.Id == x.ChangedBy).Select(t => t.Name).FirstOrDefault(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
