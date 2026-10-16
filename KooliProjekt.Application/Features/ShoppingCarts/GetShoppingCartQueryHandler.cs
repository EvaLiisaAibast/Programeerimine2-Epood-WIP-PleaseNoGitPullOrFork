using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCart>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetShoppingCartQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShoppingCart> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ShoppingCarts.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
