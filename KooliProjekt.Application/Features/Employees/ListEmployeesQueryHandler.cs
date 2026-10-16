using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Employees
{
    public class ListEmployeesQueryHandler : IRequestHandler<ListEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListEmployeesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> Handle(ListEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Employees.ToListAsync(cancellationToken);

            return result;
        }
    }
}
