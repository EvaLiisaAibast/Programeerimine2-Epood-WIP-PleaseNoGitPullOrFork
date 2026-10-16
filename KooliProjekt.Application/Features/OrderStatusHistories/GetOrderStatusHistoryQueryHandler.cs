using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class GetOrderStatusHistoryQueryHandler : IRequestHandler<GetOrderStatusHistoryQuery, OrderStatusHistory>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrderStatusHistoryQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderStatusHistory> Handle(GetOrderStatusHistoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OrderStatusHistories.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
