using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetProductImageQueryHandler : IRequestHandler<GetProductImageQuery, ProductImage>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductImageQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductImage> Handle(GetProductImageQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductImages.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
