using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Brands
{
    public class ListBrandsQueryHandler : IRequestHandler<ListBrandsQuery, OperationResult<PagedResult<BrandListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListBrandsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<BrandListItemDto>>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<BrandListItemDto>>();

            response.Value = await _dbContext.Brands
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new BrandListItemDto
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
