using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Reviews
{
    public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, OperationResult<ReviewDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReviewQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ReviewDto>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ReviewDto>();

            response.Value = await _dbContext.Reviews
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ReviewDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    ProductId = x.ProductId,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    OrderLineId = x.OrderLineId,
                    Rating = x.Rating,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    Status = x.Status,
                    Responses = _dbContext.ReviewResponses
                        .Where(c => c.ReviewId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new ReviewResponseDto
                        {
                            Id = c.Id,
                            ReviewId = c.ReviewId,
                            ReviewTitle = _dbContext.Reviews.Where(t => t.Id == c.ReviewId).Select(t => t.Title).FirstOrDefault(),
                            EmployeeId = c.EmployeeId,
                            EmployeeName = _dbContext.Employees.Where(t => t.Id == c.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                            Content = c.Content,
                            CreatedAt = c.CreatedAt,
                        })
                        .ToList(),
                    Images = _dbContext.ReviewImages
                        .Where(c => c.ReviewId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new ReviewImageDto
                        {
                            Id = c.Id,
                            ReviewId = c.ReviewId,
                            ReviewTitle = _dbContext.Reviews.Where(t => t.Id == c.ReviewId).Select(t => t.Title).FirstOrDefault(),
                            Url = c.Url,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
