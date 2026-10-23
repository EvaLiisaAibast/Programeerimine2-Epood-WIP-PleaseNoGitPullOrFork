using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class GetProductVideoQueryHandler : IRequestHandler<GetProductVideoQuery, OperationResult<ProductVideoDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductVideoQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProductVideoDto>> Handle(GetProductVideoQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProductVideoDto>();

            response.Value = await _dbContext.ProductVideos
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ProductVideoDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    Url = x.Url,
                    Title = x.Title,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
