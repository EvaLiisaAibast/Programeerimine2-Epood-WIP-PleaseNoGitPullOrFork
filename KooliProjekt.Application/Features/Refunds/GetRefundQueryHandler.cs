using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Refunds
{
    public class GetRefundQueryHandler : IRequestHandler<GetRefundQuery, OperationResult<RefundDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetRefundQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<RefundDto>> Handle(GetRefundQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<RefundDto>();

            response.Value = await _dbContext.Refunds
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new RefundDto
                {
                    Id = x.Id,
                    PaymentId = x.PaymentId,
                    PaymentMethod = _dbContext.Payments.Where(t => t.Id == x.PaymentId).Select(t => t.Method).FirstOrDefault(),
                    Amount = x.Amount,
                    Reason = x.Reason,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
