using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class ListReviewImagesQueryHandler : IRequestHandler<ListReviewImagesQuery, OperationResult<PagedResult<ReviewImageListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReviewImagesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ReviewImageListItemDto>>> Handle(ListReviewImagesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ReviewImageListItemDto>>();

            response.Value = await _dbContext.ReviewImages
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ReviewImageListItemDto
                {
                    Id = x.Id,
                    ReviewTitle = _dbContext.Reviews.Where(t => t.Id == x.ReviewId).Select(t => t.Title).FirstOrDefault(),
                    Url = x.Url,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
