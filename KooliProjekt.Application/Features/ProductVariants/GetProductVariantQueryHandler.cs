using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class GetProductVariantQueryHandler : IRequestHandler<GetProductVariantQuery, OperationResult<ProductVariantDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductVariantQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProductVariantDto>> Handle(GetProductVariantQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProductVariantDto>();

            response.Value = await _dbContext.ProductVariants
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ProductVariantDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    ProductCode = x.ProductCode,
                    Barcode = x.Barcode,
                    Price = x.Price,
                    WeightKg = x.WeightKg,
                    Status = x.Status,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
