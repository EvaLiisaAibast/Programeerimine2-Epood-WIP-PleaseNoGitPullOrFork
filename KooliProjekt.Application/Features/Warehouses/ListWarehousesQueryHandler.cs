using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Warehouses
{
    public class ListWarehousesQueryHandler : IRequestHandler<ListWarehousesQuery, IEnumerable<Warehouse>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWarehousesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Warehouse>> Handle(ListWarehousesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Warehouses.ToListAsync(cancellationToken);

            return result;
        }
    }
}
