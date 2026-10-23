using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CartItems
{
    public class ListCartItemsQueryHandler : IRequestHandler<ListCartItemsQuery, OperationResult<PagedResult<CartItemListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCartItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CartItemListItemDto>>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CartItemListItemDto>>();

            response.Value = await _dbContext.CartItems
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CartItemListItemDto
                {
                    Id = x.Id,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    Amount = x.Quantity * x.UnitPrice,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
