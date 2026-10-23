using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OrderLines
{
    public class GetOrderLineQueryHandler : IRequestHandler<GetOrderLineQuery, OperationResult<OrderLineDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrderLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OrderLineDto>> Handle(GetOrderLineQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<OrderLineDto>();

            response.Value = await _dbContext.OrderLines
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new OrderLineDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    VariantId = x.VariantId,
                    VariantCode = x.VariantCode,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    Discount = x.Discount,
                    Amount = x.Amount,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
