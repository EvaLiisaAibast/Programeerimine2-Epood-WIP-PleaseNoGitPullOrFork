using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class GetEmployeeRoleQueryHandler : IRequestHandler<GetEmployeeRoleQuery, OperationResult<EmployeeRoleDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetEmployeeRoleQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<EmployeeRoleDto>> Handle(GetEmployeeRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<EmployeeRoleDto>();

            response.Value = await _dbContext.EmployeeRoles
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new EmployeeRoleDto
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                    Role = x.Role,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
