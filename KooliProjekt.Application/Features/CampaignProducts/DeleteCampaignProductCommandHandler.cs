using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class DeleteCampaignProductCommandHandler : IRequestHandler<DeleteCampaignProductCommand, OperationResult<bool>>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteCampaignProductCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<bool>> Handle(DeleteCampaignProductCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<bool>();

            if (request.Id <= 0)
            {
                return response.AddError("Id peab olema suurem kui 0.");
            }

            var entity = await _dbContext.CampaignProducts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return response.AddError("Kirjet ei leitud.");
            }

            _dbContext.CampaignProducts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = true;

            return response;
        }
    }
}
