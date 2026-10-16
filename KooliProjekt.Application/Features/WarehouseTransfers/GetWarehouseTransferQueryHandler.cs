using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class GetWarehouseTransferQueryHandler : IRequestHandler<GetWarehouseTransferQuery, WarehouseTransfer>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWarehouseTransferQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WarehouseTransfer> Handle(GetWarehouseTransferQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WarehouseTransfers.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
