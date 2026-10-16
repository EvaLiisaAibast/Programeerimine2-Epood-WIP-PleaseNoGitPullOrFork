using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Warehouses
{
    public class GetWarehouseQueryHandler : IRequestHandler<GetWarehouseQuery, Warehouse>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWarehouseQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Warehouse> Handle(GetWarehouseQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Warehouses.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
