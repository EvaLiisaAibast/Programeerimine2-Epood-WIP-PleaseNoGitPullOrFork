using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Customers
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCustomersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Customers.ToListAsync(cancellationToken);

            return result;
        }
    }
}
