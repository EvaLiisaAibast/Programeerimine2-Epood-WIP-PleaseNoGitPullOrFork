using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Suppliers
{
    public class ListSuppliersQueryHandler : IRequestHandler<ListSuppliersQuery, IEnumerable<Supplier>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListSuppliersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Supplier>> Handle(ListSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Suppliers.ToListAsync(cancellationToken);

            return result;
        }
    }
}
