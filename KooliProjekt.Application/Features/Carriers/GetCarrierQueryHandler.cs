using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Carriers
{
    public class GetCarrierQueryHandler : IRequestHandler<GetCarrierQuery, OperationResult<CarrierDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCarrierQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CarrierDto>> Handle(GetCarrierQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CarrierDto>();

            response.Value = await _dbContext.Carriers
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CarrierDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Website = x.Website,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
