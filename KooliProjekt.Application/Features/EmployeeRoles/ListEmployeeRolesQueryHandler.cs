using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class ListEmployeeRolesQueryHandler : IRequestHandler<ListEmployeeRolesQuery, OperationResult<PagedResult<EmployeeRoleListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListEmployeeRolesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<EmployeeRoleListItemDto>>> Handle(ListEmployeeRolesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<EmployeeRoleListItemDto>>();

            response.Value = await _dbContext.EmployeeRoles
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new EmployeeRoleListItemDto
                {
                    Id = x.Id,
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                    Role = x.Role,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
