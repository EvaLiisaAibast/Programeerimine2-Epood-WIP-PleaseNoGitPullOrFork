using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Brands
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, OperationResult<BrandDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetBrandQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<BrandDto>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<BrandDto>();

            response.Value = await _dbContext.Brands
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new BrandDto
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
