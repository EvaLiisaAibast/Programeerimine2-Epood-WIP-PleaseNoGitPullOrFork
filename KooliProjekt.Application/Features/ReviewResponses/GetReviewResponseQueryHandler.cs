using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class GetReviewResponseQueryHandler : IRequestHandler<GetReviewResponseQuery, ReviewResponse>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReviewResponseQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReviewResponse> Handle(GetReviewResponseQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReviewResponses.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
