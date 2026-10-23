using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class ListProductImagesQueryHandler : IRequestHandler<ListProductImagesQuery, OperationResult<PagedResult<ProductImageListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductImagesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProductImageListItemDto>>> Handle(ListProductImagesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProductImageListItemDto>>();

            response.Value = await _dbContext.ProductImages
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ProductImageListItemDto
                {
                    Id = x.Id,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    Url = x.Url,
                    SortOrder = x.SortOrder,
                    IsMain = x.IsMain,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
