using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class ListCampaignProductsQueryHandler : IRequestHandler<ListCampaignProductsQuery, OperationResult<PagedResult<CampaignProductListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCampaignProductsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CampaignProductListItemDto>>> Handle(ListCampaignProductsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CampaignProductListItemDto>>();

            response.Value = await _dbContext.CampaignProducts
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CampaignProductListItemDto
                {
                    Id = x.Id,
                    CampaignName = _dbContext.Campaigns.Where(t => t.Id == x.CampaignId).Select(t => t.Name).FirstOrDefault(),
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    DiscountPercent = x.DiscountPercent,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
