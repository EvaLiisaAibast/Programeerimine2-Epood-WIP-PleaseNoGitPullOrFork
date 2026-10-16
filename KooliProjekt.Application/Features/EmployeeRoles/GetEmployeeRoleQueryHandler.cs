using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class GetEmployeeRoleQueryHandler : IRequestHandler<GetEmployeeRoleQuery, EmployeeRole>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetEmployeeRoleQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeRole> Handle(GetEmployeeRoleQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.EmployeeRoles.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
