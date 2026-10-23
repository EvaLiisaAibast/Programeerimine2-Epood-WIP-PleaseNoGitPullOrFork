using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetProductImageQueryHandler : IRequestHandler<GetProductImageQuery, OperationResult<ProductImageDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProductImageQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProductImageDto>> Handle(GetProductImageQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProductImageDto>();

            response.Value = await _dbContext.ProductImages
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ProductImageDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = _dbContext.Products.Where(t => t.Id == x.ProductId).Select(t => t.Name).FirstOrDefault(),
                    Url = x.Url,
                    AltText = x.AltText,
                    SortOrder = x.SortOrder,
                    IsMain = x.IsMain,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
