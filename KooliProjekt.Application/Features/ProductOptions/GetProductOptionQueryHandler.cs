using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class GetProductOptionQueryHandler : IRequestHandler<GetProductOptionQuery, OperationResult<ProductOptionDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductOptionQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProductOptionDto>> Handle(GetProductOptionQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProductOptionDto>();

            response.Value = await _dbContext.ProductOptions
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ProductOptionDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    Name = x.Name,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
