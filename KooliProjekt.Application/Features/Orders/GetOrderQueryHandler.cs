using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Orders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOrderQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Orders.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
