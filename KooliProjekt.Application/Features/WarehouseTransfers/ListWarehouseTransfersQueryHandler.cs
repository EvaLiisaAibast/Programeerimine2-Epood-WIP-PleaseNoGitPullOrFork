using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class ListWarehouseTransfersQueryHandler : IRequestHandler<ListWarehouseTransfersQuery, IEnumerable<WarehouseTransfer>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWarehouseTransfersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<WarehouseTransfer>> Handle(ListWarehouseTransfersQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WarehouseTransfers.ToListAsync(cancellationToken);

            return result;
        }
    }
}
