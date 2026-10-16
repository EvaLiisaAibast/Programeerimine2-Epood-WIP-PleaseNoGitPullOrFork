using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Employees
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Employee>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetEmployeeQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Employees.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
