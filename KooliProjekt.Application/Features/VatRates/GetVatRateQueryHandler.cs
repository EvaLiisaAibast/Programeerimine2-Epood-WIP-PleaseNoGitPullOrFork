using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.VatRates
{
    public class GetVatRateQueryHandler : IRequestHandler<GetVatRateQuery, OperationResult<VatRateDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetVatRateQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<VatRateDto>> Handle(GetVatRateQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<VatRateDto>();

            response.Value = await _dbContext.VatRates
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new VatRateDto
                {
                    Id = x.Id,
                    Country = x.Country,
                    Rate = x.Rate,
                    ValidFrom = x.ValidFrom,
                    ValidTo = x.ValidTo,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
