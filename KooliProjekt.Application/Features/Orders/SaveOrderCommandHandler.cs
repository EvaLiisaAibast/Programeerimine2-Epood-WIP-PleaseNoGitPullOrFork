using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Orders
{
    public class SaveOrderCommandHandler : IRequestHandler<SaveOrderCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int>();

            if (request.Data == null)
            {
                return response.AddError("Andmed puuduvad.");
            }

            if (request.Data.Id < 0)
            {
                return response.AddError("Id ei tohi olla negatiivne.");
            }

            Order entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Order();
                _dbContext.Orders.Add(entity);
            }

            entity.OrderNumber = request.Data.OrderNumber;
            entity.CustomerId = request.Data.CustomerId;
            entity.InvoiceAddressId = request.Data.InvoiceAddressId;
            entity.DeliveryAddressId = request.Data.DeliveryAddressId;
            entity.OrderDate = request.Data.OrderDate;
            entity.PaidAt = request.Data.PaidAt;
            entity.SentAt = request.Data.SentAt;
            entity.DeliveredAt = request.Data.DeliveredAt;
            entity.Subtotal = request.Data.Subtotal;
            entity.Discount = request.Data.Discount;
            entity.Vat = request.Data.Vat;
            entity.ShippingCost = request.Data.ShippingCost;
            entity.Amount = request.Data.Amount;
            entity.Status = request.Data.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
