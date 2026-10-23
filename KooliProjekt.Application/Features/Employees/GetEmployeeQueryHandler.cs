using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Employees
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, OperationResult<EmployeeDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetEmployeeQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<EmployeeDto>();

            response.Value = await _dbContext.Employees
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = _dbContext.Departments.Where(t => t.Id == x.DepartmentId).Select(t => t.Name).FirstOrDefault(),
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
