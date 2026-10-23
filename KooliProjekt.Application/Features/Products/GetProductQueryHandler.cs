using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, OperationResult<ProductDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProductDto>();

            response.Value = await _dbContext.Products
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    CategoryName = _dbContext.Categories.Where(t => t.Id == x.CategoryId).Select(t => t.Name).FirstOrDefault(),
                    BrandId = x.BrandId,
                    BrandName = _dbContext.Brands.Where(t => t.Id == x.BrandId).Select(t => t.Name).FirstOrDefault(),
                    Name = x.Name,
                    Description = x.Description,
                    BasePrice = x.BasePrice,
                    Price = x.Price,
                    WeightKg = x.WeightKg,
                    ImageUrl = x.ImageUrl,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    Images = _dbContext.ProductImages
                        .Where(c => c.ProductId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new ProductImageDto
                        {
                            Id = c.Id,
                            ProductId = c.ProductId,
                            ProductName = _dbContext.Products.Where(t => t.Id == c.ProductId).Select(t => t.Name).FirstOrDefault(),
                            Url = c.Url,
                            AltText = c.AltText,
                            SortOrder = c.SortOrder,
                            IsMain = c.IsMain,
                        })
                        .ToList(),
                    Variants = _dbContext.ProductVariants
                        .Where(c => c.ProductId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new ProductVariantDto
                        {
                            Id = c.Id,
                            ProductId = c.ProductId,
                            ProductName = _dbContext.Products.Where(t => t.Id == c.ProductId).Select(t => t.Name).FirstOrDefault(),
                            ProductCode = c.ProductCode,
                            Barcode = c.Barcode,
                            Price = c.Price,
                            WeightKg = c.WeightKg,
                            Status = c.Status,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
