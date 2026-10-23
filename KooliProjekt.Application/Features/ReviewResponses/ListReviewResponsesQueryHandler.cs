using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class ListReviewResponsesQueryHandler : IRequestHandler<ListReviewResponsesQuery, OperationResult<PagedResult<ReviewResponseListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReviewResponsesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ReviewResponseListItemDto>>> Handle(ListReviewResponsesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ReviewResponseListItemDto>>();

            response.Value = await _dbContext.ReviewResponses
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ReviewResponseListItemDto
                {
                    Id = x.Id,
                    ReviewTitle = _dbContext.Reviews.Where(t => t.Id == x.ReviewId).Select(t => t.Title).FirstOrDefault(),
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
