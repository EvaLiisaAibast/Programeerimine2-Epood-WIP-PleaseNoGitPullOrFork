using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Departments
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, Department>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetDepartmentQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Departments.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
