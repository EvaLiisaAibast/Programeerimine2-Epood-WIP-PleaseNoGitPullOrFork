using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class ListReturnLinesQueryHandler : IRequestHandler<ListReturnLinesQuery, OperationResult<PagedResult<ReturnLineListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListReturnLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ReturnLineListItemDto>>> Handle(ListReturnLinesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ReturnLineListItemDto>>();

            response.Value = await _dbContext.ReturnLines
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ReturnLineListItemDto
                {
                    Id = x.Id,
                    ReturnRequestId = x.ReturnRequestId,
                    OrderLineId = x.OrderLineId,
                    Quantity = x.Quantity,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
