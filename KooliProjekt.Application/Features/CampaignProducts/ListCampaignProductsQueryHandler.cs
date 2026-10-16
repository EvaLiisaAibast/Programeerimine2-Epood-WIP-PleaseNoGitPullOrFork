using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class ListCampaignProductsQueryHandler : IRequestHandler<ListCampaignProductsQuery, IEnumerable<CampaignProduct>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCampaignProductsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CampaignProduct>> Handle(ListCampaignProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.CampaignProducts.ToListAsync(cancellationToken);

            return result;
        }
    }
}
