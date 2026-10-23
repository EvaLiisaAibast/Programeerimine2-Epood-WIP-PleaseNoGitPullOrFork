using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class ListPriceHistoriesQueryHandler : IRequestHandler<ListPriceHistoriesQuery, OperationResult<PagedResult<PriceHistoryListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPriceHistoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<PriceHistoryListItemDto>>> Handle(ListPriceHistoriesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<PriceHistoryListItemDto>>();

            response.Value = await _dbContext.PriceHistories
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new PriceHistoryListItemDto
                {
                    Id = x.Id,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    CurrentPrice = x.CurrentPrice,
                    ValidFrom = x.ValidFrom,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
