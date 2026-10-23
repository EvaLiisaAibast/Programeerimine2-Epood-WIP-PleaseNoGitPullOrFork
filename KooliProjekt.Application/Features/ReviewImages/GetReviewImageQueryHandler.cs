using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class GetReviewImageQueryHandler : IRequestHandler<GetReviewImageQuery, OperationResult<ReviewImageDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReviewImageQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ReviewImageDto>> Handle(GetReviewImageQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ReviewImageDto>();

            response.Value = await _dbContext.ReviewImages
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ReviewImageDto
                {
                    Id = x.Id,
                    ReviewId = x.ReviewId,
                    ReviewTitle = _dbContext.Reviews.Where(t => t.Id == x.ReviewId).Select(t => t.Title).FirstOrDefault(),
                    Url = x.Url,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
