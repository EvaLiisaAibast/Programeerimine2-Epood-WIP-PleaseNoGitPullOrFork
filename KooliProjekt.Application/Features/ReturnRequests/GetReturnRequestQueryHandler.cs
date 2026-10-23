using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class GetReturnRequestQueryHandler : IRequestHandler<GetReturnRequestQuery, OperationResult<ReturnRequestDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReturnRequestQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ReturnRequestDto>> Handle(GetReturnRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ReturnRequestDto>();

            response.Value = await _dbContext.ReturnRequests
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ReturnRequestDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    OrderNumber = _dbContext.Orders.Where(t => t.Id == x.OrderId).Select(t => t.OrderNumber).FirstOrDefault(),
                    Status = x.Status,
                    Reason = x.Reason,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
