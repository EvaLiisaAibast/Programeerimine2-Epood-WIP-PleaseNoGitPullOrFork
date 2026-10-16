using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductVariants
{
    public class GetProductVariantQueryHandler : IRequestHandler<GetProductVariantQuery, ProductVariant>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductVariantQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductVariant> Handle(GetProductVariantQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductVariants.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
