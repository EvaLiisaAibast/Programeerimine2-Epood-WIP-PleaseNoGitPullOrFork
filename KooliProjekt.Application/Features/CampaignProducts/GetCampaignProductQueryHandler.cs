using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class GetCampaignProductQueryHandler : IRequestHandler<GetCampaignProductQuery, CampaignProduct>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCampaignProductQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CampaignProduct> Handle(GetCampaignProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.CampaignProducts.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
