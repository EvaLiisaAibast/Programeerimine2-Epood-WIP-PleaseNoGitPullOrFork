using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, OperationResult<ShoppingCartDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetShoppingCartQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ShoppingCartDto>> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ShoppingCartDto>();

            response.Value = await _dbContext.ShoppingCarts
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ShoppingCartDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Items = _dbContext.CartItems
                        .Where(c => c.CartId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new CartItemDto
                        {
                            Id = c.Id,
                            CartId = c.CartId,
                            VariantId = c.VariantId,
                            VariantCode = _dbContext.ProductVariants.Where(t => t.Id == c.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                            Quantity = c.Quantity,
                            UnitPrice = c.UnitPrice,
                            Amount = c.Quantity * c.UnitPrice,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
