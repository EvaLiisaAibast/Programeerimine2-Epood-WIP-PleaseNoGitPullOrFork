using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Refunds
{
    public class GetRefundQueryHandler : IRequestHandler<GetRefundQuery, Refund>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetRefundQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Refund> Handle(GetRefundQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Refunds.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
