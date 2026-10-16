using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class ListEmployeeRolesQueryHandler : IRequestHandler<ListEmployeeRolesQuery, IEnumerable<EmployeeRole>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListEmployeeRolesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeRole>> Handle(ListEmployeeRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.EmployeeRoles.ToListAsync(cancellationToken);

            return result;
        }
    }
}
