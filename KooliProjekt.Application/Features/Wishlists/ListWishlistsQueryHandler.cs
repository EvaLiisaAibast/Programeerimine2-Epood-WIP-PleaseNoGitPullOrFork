using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Wishlists
{
    public class ListWishlistsQueryHandler : IRequestHandler<ListWishlistsQuery, OperationResult<PagedResult<WishlistListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWishlistsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<WishlistListItemDto>>> Handle(ListWishlistsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<WishlistListItemDto>>();

            response.Value = await _dbContext.Wishlists
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new WishlistListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    ItemCount = _dbContext.WishlistItems.Count(t => t.WishlistId == x.Id),
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
