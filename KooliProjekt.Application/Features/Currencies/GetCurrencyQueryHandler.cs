using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Currencies
{
    public class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, OperationResult<CurrencyDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCurrencyQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CurrencyDto>> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CurrencyDto>();

            response.Value = await _dbContext.Currencies
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CurrencyDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Symbol = x.Symbol,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
