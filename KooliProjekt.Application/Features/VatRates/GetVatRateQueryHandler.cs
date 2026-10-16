using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.VatRates
{
    public class GetVatRateQueryHandler : IRequestHandler<GetVatRateQuery, VatRate>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetVatRateQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VatRate> Handle(GetVatRateQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.VatRates.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
