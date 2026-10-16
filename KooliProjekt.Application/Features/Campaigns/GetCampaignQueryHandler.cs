using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Campaigns
{
    public class GetCampaignQueryHandler : IRequestHandler<GetCampaignQuery, Campaign>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCampaignQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Campaign> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Campaigns.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
