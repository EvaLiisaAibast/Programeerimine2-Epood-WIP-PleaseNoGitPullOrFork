using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class ListProductOptionsQueryHandler : IRequestHandler<ListProductOptionsQuery, OperationResult<PagedResult<ProductOptionListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductOptionsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProductOptionListItemDto>>> Handle(ListProductOptionsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProductOptionListItemDto>>();

            response.Value = await _dbContext.ProductOptions
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ProductOptionListItemDto
                {
                    Id = x.Id,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    Name = x.Name,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
