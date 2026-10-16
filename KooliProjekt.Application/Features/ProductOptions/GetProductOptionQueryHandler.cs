using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductOptions
{
    public class GetProductOptionQueryHandler : IRequestHandler<GetProductOptionQuery, ProductOption>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductOptionQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductOption> Handle(GetProductOptionQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductOptions.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
