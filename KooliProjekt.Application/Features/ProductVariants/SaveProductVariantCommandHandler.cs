using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class SaveProductVariantCommandHandler : IRequestHandler<SaveProductVariantCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProductVariantCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveProductVariantCommand request, CancellationToken cancellationToken)
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

            ProductVariant entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.ProductVariants.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new ProductVariant();
                _dbContext.ProductVariants.Add(entity);
            }

            entity.ProductId = request.Data.ProductId;
            entity.ProductCode = request.Data.ProductCode;
            entity.Barcode = request.Data.Barcode;
            entity.Price = request.Data.Price;
            entity.WeightKg = request.Data.WeightKg;
            entity.Status = request.Data.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
