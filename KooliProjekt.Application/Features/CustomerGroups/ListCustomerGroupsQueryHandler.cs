using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class ListCustomerGroupsQueryHandler : IRequestHandler<ListCustomerGroupsQuery, IEnumerable<CustomerGroup>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCustomerGroupsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CustomerGroup>> Handle(ListCustomerGroupsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.CustomerGroups.ToListAsync(cancellationToken);

            return result;
        }
    }
}
