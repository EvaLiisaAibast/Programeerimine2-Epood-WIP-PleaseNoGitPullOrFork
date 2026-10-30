using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Products
{
    public class SaveProductCommandHandler : IRequestHandler<SaveProductCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProductCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveProductCommand request, CancellationToken cancellationToken)
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

            Product entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Product();
                _dbContext.Products.Add(entity);
            }

            entity.CategoryId = request.Data.CategoryId;
            entity.BrandId = request.Data.BrandId;
            entity.Name = request.Data.Name;
            entity.Description = request.Data.Description;
            entity.BasePrice = request.Data.BasePrice;
            entity.Price = request.Data.Price;
            entity.WeightKg = request.Data.WeightKg;
            entity.ImageUrl = request.Data.ImageUrl;
            entity.Status = request.Data.Status;
            entity.CreatedAt = request.Data.CreatedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
