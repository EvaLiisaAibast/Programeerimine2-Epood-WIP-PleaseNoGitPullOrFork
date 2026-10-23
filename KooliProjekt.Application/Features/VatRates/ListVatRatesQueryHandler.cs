using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.VatRates
{
    public class ListVatRatesQueryHandler : IRequestHandler<ListVatRatesQuery, OperationResult<PagedResult<VatRateListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListVatRatesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<VatRateListItemDto>>> Handle(ListVatRatesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<VatRateListItemDto>>();

            response.Value = await _dbContext.VatRates
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new VatRateListItemDto
                {
                    Id = x.Id,
                    Country = x.Country,
                    Rate = x.Rate,
                    ValidFrom = x.ValidFrom,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
