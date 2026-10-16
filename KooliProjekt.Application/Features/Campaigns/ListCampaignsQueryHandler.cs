using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Campaigns
{
    public class ListCampaignsQueryHandler : IRequestHandler<ListCampaignsQuery, IEnumerable<Campaign>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCampaignsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Campaign>> Handle(ListCampaignsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Campaigns.ToListAsync(cancellationToken);

            return result;
        }
    }
}
