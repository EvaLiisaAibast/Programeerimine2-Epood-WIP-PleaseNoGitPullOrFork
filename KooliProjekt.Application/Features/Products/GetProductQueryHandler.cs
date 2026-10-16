using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Products.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
