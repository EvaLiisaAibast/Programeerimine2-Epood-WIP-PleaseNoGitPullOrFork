using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class ListWarehouseTransferLinesQueryHandler : IRequestHandler<ListWarehouseTransferLinesQuery, IEnumerable<WarehouseTransferLine>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWarehouseTransferLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<WarehouseTransferLine>> Handle(ListWarehouseTransferLinesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WarehouseTransferLines.ToListAsync(cancellationToken);

            return result;
        }
    }
}
