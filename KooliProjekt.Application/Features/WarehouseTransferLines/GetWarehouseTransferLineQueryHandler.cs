using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class GetWarehouseTransferLineQueryHandler : IRequestHandler<GetWarehouseTransferLineQuery, WarehouseTransferLine>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWarehouseTransferLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WarehouseTransferLine> Handle(GetWarehouseTransferLineQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.WarehouseTransferLines.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
