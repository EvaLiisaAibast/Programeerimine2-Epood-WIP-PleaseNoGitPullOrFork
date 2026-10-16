using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OrderLines
{
    public class GetOrderLineQueryHandler : IRequestHandler<GetOrderLineQuery, OrderLine>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrderLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderLine> Handle(GetOrderLineQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OrderLines.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
