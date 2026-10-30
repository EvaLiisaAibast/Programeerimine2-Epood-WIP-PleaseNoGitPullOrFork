using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class SaveCampaignProductCommandHandler : IRequestHandler<SaveCampaignProductCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCampaignProductCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveCampaignProductCommand request, CancellationToken cancellationToken)
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

            CampaignProduct entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.CampaignProducts.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new CampaignProduct();
                _dbContext.CampaignProducts.Add(entity);
            }

            entity.CampaignId = request.Data.CampaignId;
            entity.ProductId = request.Data.ProductId;
            entity.DiscountPercent = request.Data.DiscountPercent;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
