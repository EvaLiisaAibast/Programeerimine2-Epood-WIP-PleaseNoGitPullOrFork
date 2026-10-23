using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class GetWarehouseTransferLineQueryHandler : IRequestHandler<GetWarehouseTransferLineQuery, OperationResult<WarehouseTransferLineDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWarehouseTransferLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WarehouseTransferLineDto>> Handle(GetWarehouseTransferLineQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<WarehouseTransferLineDto>();

            response.Value = await _dbContext.WarehouseTransferLines
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new WarehouseTransferLineDto
                {
                    Id = x.Id,
                    TransferId = x.TransferId,
                    VariantId = x.VariantId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    Quantity = x.Quantity,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
