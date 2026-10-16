using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.CartItems
{
    public class ListCartItemsQueryHandler : IRequestHandler<ListCartItemsQuery, IEnumerable<CartItem>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCartItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CartItem>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.CartItems.ToListAsync(cancellationToken);

            return result;
        }
    }
}
