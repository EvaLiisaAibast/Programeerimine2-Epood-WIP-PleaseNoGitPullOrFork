using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class GetPriceHistoryQueryHandler : IRequestHandler<GetPriceHistoryQuery, OperationResult<PriceHistoryDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPriceHistoryQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PriceHistoryDto>> Handle(GetPriceHistoryQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PriceHistoryDto>();

            response.Value = await _dbContext.PriceHistories
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new PriceHistoryDto
                {
                    Id = x.Id,
                    VariantId = x.VariantId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    CurrentPrice = x.CurrentPrice,
                    ValidFrom = x.ValidFrom,
                    ValidTo = x.ValidTo,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
