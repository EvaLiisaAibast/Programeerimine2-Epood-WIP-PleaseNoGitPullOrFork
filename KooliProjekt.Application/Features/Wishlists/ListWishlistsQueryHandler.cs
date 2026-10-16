using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Wishlists
{
    public class ListWishlistsQueryHandler : IRequestHandler<ListWishlistsQuery, IEnumerable<Wishlist>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWishlistsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Wishlist>> Handle(ListWishlistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Wishlists.ToListAsync(cancellationToken);

            return result;
        }
    }
}
