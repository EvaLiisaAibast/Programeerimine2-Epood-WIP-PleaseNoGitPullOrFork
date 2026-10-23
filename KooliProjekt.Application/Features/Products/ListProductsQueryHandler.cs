using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Products
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, OperationResult<PagedResult<ProductListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProductListItemDto>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProductListItemDto>>();

            response.Value = await _dbContext.Products
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ProductListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryName = _dbContext.Categories.Where(t => t.Id == x.CategoryId).Select(t => t.Name).FirstOrDefault(),
                    BrandName = _dbContext.Brands.Where(t => t.Id == x.BrandId).Select(t => t.Name).FirstOrDefault(),
                    Price = x.Price,
                    Status = x.Status,
                    ImageUrl = x.ImageUrl,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
