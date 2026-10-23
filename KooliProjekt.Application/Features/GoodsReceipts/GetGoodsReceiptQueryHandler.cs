using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class GetGoodsReceiptQueryHandler : IRequestHandler<GetGoodsReceiptQuery, OperationResult<GoodsReceiptDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetGoodsReceiptQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<GoodsReceiptDto>> Handle(GetGoodsReceiptQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<GoodsReceiptDto>();

            response.Value = await _dbContext.GoodsReceipts
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new GoodsReceiptDto
                {
                    Id = x.Id,
                    PurchaseOrderLineId = x.PurchaseOrderLineId,
                    Quantity = x.Quantity,
                    CreatedAt = x.CreatedAt,
                    EmployeeId = x.EmployeeId,
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
