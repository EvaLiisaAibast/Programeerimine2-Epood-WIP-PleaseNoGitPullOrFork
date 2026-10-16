using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Carriers
{
    public class GetCarrierQueryHandler : IRequestHandler<GetCarrierQuery, Carrier>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarrierQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Carrier> Handle(GetCarrierQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Carriers.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
