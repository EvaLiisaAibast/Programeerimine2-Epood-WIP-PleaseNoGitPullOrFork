using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Refunds
{
    public class ListRefundsQueryHandler : IRequestHandler<ListRefundsQuery, IEnumerable<Refund>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListRefundsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Refund>> Handle(ListRefundsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Refunds.ToListAsync(cancellationToken);

            return result;
        }
    }
}
