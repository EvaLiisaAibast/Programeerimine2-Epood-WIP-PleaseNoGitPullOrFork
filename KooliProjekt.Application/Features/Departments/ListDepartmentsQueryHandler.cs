using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Departments
{
    public class ListDepartmentsQueryHandler : IRequestHandler<ListDepartmentsQuery, OperationResult<PagedResult<DepartmentListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListDepartmentsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<DepartmentListItemDto>>> Handle(ListDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<DepartmentListItemDto>>();

            response.Value = await _dbContext.Departments
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new DepartmentListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
