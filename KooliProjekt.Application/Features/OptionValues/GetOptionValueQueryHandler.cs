using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class GetOptionValueQueryHandler : IRequestHandler<GetOptionValueQuery, OperationResult<OptionValueDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOptionValueQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<OptionValueDto>> Handle(GetOptionValueQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<OptionValueDto>();

            response.Value = await _dbContext.OptionValues
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new OptionValueDto
                {
                    Id = x.Id,
                    ProductOptionId = x.ProductOptionId,
                    ProductOptionName = _dbContext.ProductOptions.Where(t => t.Id == x.ProductOptionId).Select(t => t.Name).FirstOrDefault(),
                    Value = x.Value,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
