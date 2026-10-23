using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class GetWarehouseQueryHandler : IRequestHandler<GetWarehouseQuery, OperationResult<WarehouseDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWarehouseQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WarehouseDto>> Handle(GetWarehouseQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<WarehouseDto>();

            response.Value = await _dbContext.Warehouses
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new WarehouseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    AddressId = x.AddressId,
                    AddressName = _dbContext.Addresses.Where(t => t.Id == x.AddressId).Select(t => t.Street + " " + t.HouseNumber + ", " + t.City).FirstOrDefault(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
