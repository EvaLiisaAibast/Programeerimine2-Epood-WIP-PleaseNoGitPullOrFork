using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class ListShoppingCartsQueryHandler : IRequestHandler<ListShoppingCartsQuery, IEnumerable<ShoppingCart>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListShoppingCartsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ShoppingCart>> Handle(ListShoppingCartsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ShoppingCarts.ToListAsync(cancellationToken);

            return result;
        }
    }
}
