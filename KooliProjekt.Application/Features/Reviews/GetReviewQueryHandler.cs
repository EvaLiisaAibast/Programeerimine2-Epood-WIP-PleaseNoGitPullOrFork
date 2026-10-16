using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Reviews
{
    public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, Review>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReviewQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Review> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Reviews.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
