using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CartItems
{
    public class GetCartItemQueryHandler : IRequestHandler<GetCartItemQuery, OperationResult<CartItemDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCartItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CartItemDto>> Handle(GetCartItemQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CartItemDto>();

            response.Value = await _dbContext.CartItems
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CartItemDto
                {
                    Id = x.Id,
                    CartId = x.CartId,
                    VariantId = x.VariantId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    Amount = x.Quantity * x.UnitPrice,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
