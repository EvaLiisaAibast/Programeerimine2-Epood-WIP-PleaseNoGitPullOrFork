using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductVideos
{
    public class GetProductVideoQueryHandler : IRequestHandler<GetProductVideoQuery, ProductVideo>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductVideoQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductVideo> Handle(GetProductVideoQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductVideos.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
