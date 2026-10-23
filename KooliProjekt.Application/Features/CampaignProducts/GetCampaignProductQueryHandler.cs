using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class GetCampaignProductQueryHandler : IRequestHandler<GetCampaignProductQuery, OperationResult<CampaignProductDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCampaignProductQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CampaignProductDto>> Handle(GetCampaignProductQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CampaignProductDto>();

            response.Value = await _dbContext.CampaignProducts
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CampaignProductDto
                {
                    Id = x.Id,
                    CampaignId = x.CampaignId,
                    CampaignName = _dbContext.Campaigns.Where(t => t.Id == x.CampaignId).Select(t => t.Name).FirstOrDefault(),
                    ProductId = x.ProductId,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    DiscountPercent = x.DiscountPercent,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
