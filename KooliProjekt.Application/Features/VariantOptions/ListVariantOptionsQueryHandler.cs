using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class ListVariantOptionsQueryHandler : IRequestHandler<ListVariantOptionsQuery, OperationResult<PagedResult<VariantOptionListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListVariantOptionsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<VariantOptionListItemDto>>> Handle(ListVariantOptionsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<VariantOptionListItemDto>>();

            response.Value = await _dbContext.VariantOptions
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new VariantOptionListItemDto
                {
                    Id = x.Id,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    OptionValueName = _dbContext.OptionValues.Where(t => t.Id == x.OptionValueId).Select(t => t.Value).FirstOrDefault(),
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
