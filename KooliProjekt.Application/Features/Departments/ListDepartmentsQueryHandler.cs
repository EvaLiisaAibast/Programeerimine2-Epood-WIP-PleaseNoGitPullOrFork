using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Departments
{
    public class ListDepartmentsQueryHandler : IRequestHandler<ListDepartmentsQuery, IEnumerable<Department>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListDepartmentsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> Handle(ListDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Departments.ToListAsync(cancellationToken);

            return result;
        }
    }
}
