using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Employees
{
    public class ListEmployeesQueryHandler : IRequestHandler<ListEmployeesQuery, OperationResult<PagedResult<EmployeeListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListEmployeesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<EmployeeListItemDto>>> Handle(ListEmployeesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<EmployeeListItemDto>>();

            response.Value = await _dbContext.Employees
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new EmployeeListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    DepartmentName = _dbContext.Departments.Where(t => t.Id == x.DepartmentId).Select(t => t.Name).FirstOrDefault(),
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
