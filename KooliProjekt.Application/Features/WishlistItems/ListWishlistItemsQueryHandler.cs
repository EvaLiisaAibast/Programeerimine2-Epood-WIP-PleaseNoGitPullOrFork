using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class ListWishlistItemsQueryHandler : IRequestHandler<ListWishlistItemsQuery, OperationResult<PagedResult<WishlistItemListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWishlistItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<WishlistItemListItemDto>>> Handle(ListWishlistItemsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<WishlistItemListItemDto>>();

            response.Value = await _dbContext.WishlistItems
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new WishlistItemListItemDto
                {
                    Id = x.Id,
                    WishlistName = _dbContext.Wishlists.Where(t => t.Id == x.WishlistId).Select(t => t.Name).FirstOrDefault(),
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    AddedAt = x.AddedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
