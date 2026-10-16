using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Carriers
{
    public class ListCarriersQueryHandler : IRequestHandler<ListCarriersQuery, IEnumerable<Carrier>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCarriersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Carrier>> Handle(ListCarriersQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Carriers.ToListAsync(cancellationToken);

            return result;
        }
    }
}
