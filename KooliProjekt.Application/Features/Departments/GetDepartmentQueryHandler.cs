using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Departments
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, OperationResult<DepartmentDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetDepartmentQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<DepartmentDto>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<DepartmentDto>();

            response.Value = await _dbContext.Departments
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new DepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
