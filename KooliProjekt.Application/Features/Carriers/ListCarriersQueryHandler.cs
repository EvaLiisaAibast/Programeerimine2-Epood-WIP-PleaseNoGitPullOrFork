using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Carriers
{
    public class ListCarriersQueryHandler : IRequestHandler<ListCarriersQuery, OperationResult<PagedResult<CarrierListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCarriersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CarrierListItemDto>>> Handle(ListCarriersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CarrierListItemDto>>();

            response.Value = await _dbContext.Carriers
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CarrierListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Website = x.Website,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
