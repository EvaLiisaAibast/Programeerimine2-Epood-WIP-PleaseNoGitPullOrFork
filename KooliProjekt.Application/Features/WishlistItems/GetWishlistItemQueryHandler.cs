using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class GetWishlistItemQueryHandler : IRequestHandler<GetWishlistItemQuery, OperationResult<WishlistItemDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWishlistItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WishlistItemDto>> Handle(GetWishlistItemQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<WishlistItemDto>();

            response.Value = await _dbContext.WishlistItems
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new WishlistItemDto
                {
                    Id = x.Id,
                    WishlistId = x.WishlistId,
                    WishlistName = _dbContext.Wishlists.Where(t => t.Id == x.WishlistId).Select(t => t.Name).FirstOrDefault(),
                    VariantId = x.VariantId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    AddedAt = x.AddedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
