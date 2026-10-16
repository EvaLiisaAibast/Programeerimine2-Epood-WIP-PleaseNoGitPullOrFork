using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WishlistItems
{
    public class GetWishlistItemQueryHandler : IRequestHandler<GetWishlistItemQuery, WishlistItem>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWishlistItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WishlistItem> Handle(GetWishlistItemQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WishlistItems.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
