using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class GetReviewResponseQueryHandler : IRequestHandler<GetReviewResponseQuery, OperationResult<ReviewResponseDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReviewResponseQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ReviewResponseDto>> Handle(GetReviewResponseQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ReviewResponseDto>();

            response.Value = await _dbContext.ReviewResponses
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ReviewResponseDto
                {
                    Id = x.Id,
                    ReviewId = x.ReviewId,
                    ReviewTitle = _dbContext.Reviews.Where(t => t.Id == x.ReviewId).Select(t => t.Title).FirstOrDefault(),
                    EmployeeId = x.EmployeeId,
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
