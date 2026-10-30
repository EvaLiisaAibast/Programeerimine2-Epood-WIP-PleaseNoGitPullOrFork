using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class SaveProductImageCommandHandler : IRequestHandler<SaveProductImageCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProductImageCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveProductImageCommand request, CancellationToken cancellationToken)
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

            ProductImage entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.ProductImages.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new ProductImage();
                _dbContext.ProductImages.Add(entity);
            }

            entity.ProductId = request.Data.ProductId;
            entity.Url = request.Data.Url;
            entity.AltText = request.Data.AltText;
            entity.SortOrder = request.Data.SortOrder;
            entity.IsMain = request.Data.IsMain;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
