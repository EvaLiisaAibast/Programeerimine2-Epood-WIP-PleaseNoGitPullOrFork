using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Reviews
{
    public class ListReviewsQueryHandler : IRequestHandler<ListReviewsQuery, IEnumerable<Review>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReviewsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Review>> Handle(ListReviewsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Reviews.ToListAsync(cancellationToken);

            return result;
        }
    }
}
