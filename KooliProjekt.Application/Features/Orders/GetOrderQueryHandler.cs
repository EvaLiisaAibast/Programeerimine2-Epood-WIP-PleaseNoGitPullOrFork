using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Orders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OperationResult<OrderDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrderQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<OrderDto>();

            response.Value = await _dbContext.Orders
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    OrderNumber = x.OrderNumber,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    InvoiceAddressId = x.InvoiceAddressId,
                    DeliveryAddressId = x.DeliveryAddressId,
                    OrderDate = x.OrderDate,
                    PaidAt = x.PaidAt,
                    SentAt = x.SentAt,
                    DeliveredAt = x.DeliveredAt,
                    Subtotal = x.Subtotal,
                    Discount = x.Discount,
                    Vat = x.Vat,
                    ShippingCost = x.ShippingCost,
                    Amount = x.Amount,
                    Status = x.Status,
                    Lines = _dbContext.OrderLines
                        .Where(c => c.OrderId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new OrderLineDto
                        {
                            Id = c.Id,
                            OrderId = c.OrderId,
                            ProductId = c.ProductId,
                            ProductName = c.ProductName,
                            VariantId = c.VariantId,
                            VariantCode = c.VariantCode,
                            Quantity = c.Quantity,
                            UnitPrice = c.UnitPrice,
                            Discount = c.Discount,
                            Amount = c.Amount,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
