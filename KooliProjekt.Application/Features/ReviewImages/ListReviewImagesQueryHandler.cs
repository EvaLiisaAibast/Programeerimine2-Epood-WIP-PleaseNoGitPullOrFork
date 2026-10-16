using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ReviewImages
{
    public class ListReviewImagesQueryHandler : IRequestHandler<ListReviewImagesQuery, IEnumerable<ReviewImage>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReviewImagesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReviewImage>> Handle(ListReviewImagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReviewImages.ToListAsync(cancellationToken);

            return result;
        }
    }
}
