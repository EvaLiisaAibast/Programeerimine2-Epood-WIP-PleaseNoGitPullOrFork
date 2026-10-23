using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class GetVariantOptionQueryHandler : IRequestHandler<GetVariantOptionQuery, OperationResult<VariantOptionDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetVariantOptionQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<VariantOptionDto>> Handle(GetVariantOptionQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<VariantOptionDto>();

            response.Value = await _dbContext.VariantOptions
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new VariantOptionDto
                {
                    Id = x.Id,
                    VariantId = x.VariantId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    OptionValueId = x.OptionValueId,
                    OptionValueName = _dbContext.OptionValues.Where(t => t.Id == x.OptionValueId).Select(t => t.Value).FirstOrDefault(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
