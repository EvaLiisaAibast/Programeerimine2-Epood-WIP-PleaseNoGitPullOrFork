using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class ListReviewResponsesQueryHandler : IRequestHandler<ListReviewResponsesQuery, IEnumerable<ReviewResponse>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReviewResponsesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReviewResponse>> Handle(ListReviewResponsesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReviewResponses.ToListAsync(cancellationToken);

            return result;
        }
    }
}
