using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OrderLines
{
    public class SaveOrderLineCommandHandler : IRequestHandler<SaveOrderLineCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOrderLineCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveOrderLineCommand request, CancellationToken cancellationToken)
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

            OrderLine entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.OrderLines.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new OrderLine();
                _dbContext.OrderLines.Add(entity);
            }

            entity.OrderId = request.Data.OrderId;
            entity.ProductId = request.Data.ProductId;
            entity.ProductName = request.Data.ProductName;
            entity.VariantId = request.Data.VariantId;
            entity.VariantCode = request.Data.VariantCode;
            entity.Quantity = request.Data.Quantity;
            entity.UnitPrice = request.Data.UnitPrice;
            entity.Discount = request.Data.Discount;
            entity.Amount = request.Data.Amount;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
