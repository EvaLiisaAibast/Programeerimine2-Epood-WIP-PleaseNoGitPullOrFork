using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CartItems
{
    public class GetCartItemQueryHandler : IRequestHandler<GetCartItemQuery, CartItem>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCartItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CartItem> Handle(GetCartItemQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.CartItems.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
