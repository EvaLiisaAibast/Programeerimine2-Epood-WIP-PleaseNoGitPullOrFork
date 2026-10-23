using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class ListProductVideosQueryHandler : IRequestHandler<ListProductVideosQuery, OperationResult<PagedResult<ProductVideoListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductVideosQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProductVideoListItemDto>>> Handle(ListProductVideosQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProductVideoListItemDto>>();

            response.Value = await _dbContext.ProductVideos
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ProductVideoListItemDto
                {
                    Id = x.Id,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    Title = x.Title,
                    Url = x.Url,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
