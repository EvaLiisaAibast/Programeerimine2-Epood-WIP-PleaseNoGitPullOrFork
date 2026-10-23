using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class GetReturnLineQueryHandler : IRequestHandler<GetReturnLineQuery, OperationResult<ReturnLineDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReturnLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ReturnLineDto>> Handle(GetReturnLineQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ReturnLineDto>();

            response.Value = await _dbContext.ReturnLines
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ReturnLineDto
                {
                    Id = x.Id,
                    ReturnRequestId = x.ReturnRequestId,
                    OrderLineId = x.OrderLineId,
                    Quantity = x.Quantity,
                    Reason = x.Reason,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
