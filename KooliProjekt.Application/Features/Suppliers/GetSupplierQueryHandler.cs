using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Suppliers
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, Supplier>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetSupplierQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Suppliers.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
