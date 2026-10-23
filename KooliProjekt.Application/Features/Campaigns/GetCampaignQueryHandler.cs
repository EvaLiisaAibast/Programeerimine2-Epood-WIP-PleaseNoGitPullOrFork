using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class GetCampaignQueryHandler : IRequestHandler<GetCampaignQuery, OperationResult<CampaignDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCampaignQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CampaignDto>> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CampaignDto>();

            response.Value = await _dbContext.Campaigns
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CampaignDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = x.Status,
                    Products = _dbContext.CampaignProducts
                        .Where(c => c.CampaignId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new CampaignProductDto
                        {
                            Id = c.Id,
                            CampaignId = c.CampaignId,
                            CampaignName = _dbContext.Campaigns.Where(t => t.Id == c.CampaignId).Select(t => t.Name).FirstOrDefault(),
                            ProductId = c.ProductId,
                            ProductName = _dbContext.Products.Where(t => t.Id == c.ProductId).Select(t => t.Name).FirstOrDefault(),
                            DiscountPercent = c.DiscountPercent,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
