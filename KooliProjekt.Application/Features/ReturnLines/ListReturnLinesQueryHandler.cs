using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ReturnLines
{
    public class ListReturnLinesQueryHandler : IRequestHandler<ListReturnLinesQuery, IEnumerable<ReturnLine>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReturnLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReturnLine>> Handle(ListReturnLinesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReturnLines.ToListAsync(cancellationToken);

            return result;
        }
    }
}
