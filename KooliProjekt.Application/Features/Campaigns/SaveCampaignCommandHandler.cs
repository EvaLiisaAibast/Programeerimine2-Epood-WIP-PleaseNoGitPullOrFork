using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class SaveCampaignCommandHandler : IRequestHandler<SaveCampaignCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCampaignCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveCampaignCommand request, CancellationToken cancellationToken)
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

            Campaign entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Campaign();
                _dbContext.Campaigns.Add(entity);
            }

            entity.Name = request.Data.Name;
            entity.Description = request.Data.Description;
            entity.StartDate = request.Data.StartDate;
            entity.EndDate = request.Data.EndDate;
            entity.Status = request.Data.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
