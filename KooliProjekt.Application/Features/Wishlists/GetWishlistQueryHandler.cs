using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Wishlists
{
    public class GetWishlistQueryHandler : IRequestHandler<GetWishlistQuery, Wishlist>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWishlistQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Wishlist> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Wishlists.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
