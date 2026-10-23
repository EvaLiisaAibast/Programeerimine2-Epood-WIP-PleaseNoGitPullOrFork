using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Categories
{
    public class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, OperationResult<PagedResult<CategoryListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCategoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CategoryListItemDto>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CategoryListItemDto>>();

            response.Value = await _dbContext.Categories
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CategoryListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentCategoryName = _dbContext.Categories.Where(t => t.Id == x.ParentCategoryId).Select(t => t.Name).FirstOrDefault(),
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
