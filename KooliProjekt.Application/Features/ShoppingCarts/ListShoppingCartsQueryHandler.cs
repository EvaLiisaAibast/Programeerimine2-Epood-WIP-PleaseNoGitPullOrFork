using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class ListShoppingCartsQueryHandler : IRequestHandler<ListShoppingCartsQuery, OperationResult<PagedResult<ShoppingCartListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListShoppingCartsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ShoppingCartListItemDto>>> Handle(ListShoppingCartsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ShoppingCartListItemDto>>();

            response.Value = await _dbContext.ShoppingCarts
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ShoppingCartListItemDto
                {
                    Id = x.Id,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    ItemCount = _dbContext.CartItems.Count(t => t.CartId == x.Id),
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
