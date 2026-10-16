using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class ListReturnRequestsQueryHandler : IRequestHandler<ListReturnRequestsQuery, IEnumerable<ReturnRequest>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReturnRequestsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReturnRequest>> Handle(ListReturnRequestsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReturnRequests.ToListAsync(cancellationToken);

            return result;
        }
    }
}
