using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.WishlistItems
{
    public class ListWishlistItemsQueryHandler : IRequestHandler<ListWishlistItemsQuery, IEnumerable<WishlistItem>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWishlistItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<WishlistItem>> Handle(ListWishlistItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WishlistItems.ToListAsync(cancellationToken);

            return result;
        }
    }
}
