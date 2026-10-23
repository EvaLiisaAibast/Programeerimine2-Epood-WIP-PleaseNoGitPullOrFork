using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Wishlists
{
    public class GetWishlistQueryHandler : IRequestHandler<GetWishlistQuery, OperationResult<WishlistDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWishlistQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WishlistDto>> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<WishlistDto>();

            response.Value = await _dbContext.Wishlists
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new WishlistDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    Items = _dbContext.WishlistItems
                        .Where(c => c.WishlistId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new WishlistItemDto
                        {
                            Id = c.Id,
                            WishlistId = c.WishlistId,
                            WishlistName = _dbContext.Wishlists.Where(t => t.Id == c.WishlistId).Select(t => t.Name).FirstOrDefault(),
                            VariantId = c.VariantId,
                            VariantCode = _dbContext.ProductVariants.Where(t => t.Id == c.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                            AddedAt = c.AddedAt,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
