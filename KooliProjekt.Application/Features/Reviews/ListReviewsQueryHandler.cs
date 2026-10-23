using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Reviews
{
    public class ListReviewsQueryHandler : IRequestHandler<ListReviewsQuery, OperationResult<PagedResult<ReviewListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReviewsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ReviewListItemDto>>> Handle(ListReviewsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ReviewListItemDto>>();

            response.Value = await _dbContext.Reviews
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ReviewListItemDto
                {
                    Id = x.Id,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    Rating = x.Rating,
                    Title = x.Title,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
