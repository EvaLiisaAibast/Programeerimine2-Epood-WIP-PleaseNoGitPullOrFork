using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class ListOptionValuesQueryHandler : IRequestHandler<ListOptionValuesQuery, OperationResult<PagedResult<OptionValueListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOptionValuesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<OptionValueListItemDto>>> Handle(ListOptionValuesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<OptionValueListItemDto>>();

            response.Value = await _dbContext.OptionValues
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new OptionValueListItemDto
                {
                    Id = x.Id,
                    ProductOptionName = _dbContext.ProductOptions.Where(t => t.Id == x.ProductOptionId).Select(t => t.Name).FirstOrDefault(),
                    Value = x.Value,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
