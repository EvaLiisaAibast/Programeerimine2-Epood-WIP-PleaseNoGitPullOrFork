using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReviewImages
{
    public class GetReviewImageQueryHandler : IRequestHandler<GetReviewImageQuery, ReviewImage>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReviewImageQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReviewImage> Handle(GetReviewImageQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReviewImages.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
