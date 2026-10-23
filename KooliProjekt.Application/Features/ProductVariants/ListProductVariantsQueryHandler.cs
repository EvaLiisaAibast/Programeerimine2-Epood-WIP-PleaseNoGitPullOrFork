using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class ListProductVariantsQueryHandler : IRequestHandler<ListProductVariantsQuery, OperationResult<PagedResult<ProductVariantListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductVariantsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProductVariantListItemDto>>> Handle(ListProductVariantsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProductVariantListItemDto>>();

            response.Value = await _dbContext.ProductVariants
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ProductVariantListItemDto
                {
                    Id = x.Id,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    ProductCode = x.ProductCode,
                    Price = x.Price,
                    Status = x.Status,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
