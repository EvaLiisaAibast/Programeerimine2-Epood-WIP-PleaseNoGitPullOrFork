using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, OperationResult<SupplierDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetSupplierQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<SupplierDto>> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<SupplierDto>();

            response.Value = await _dbContext.Suppliers
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new SupplierDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ContactEmail = x.ContactEmail,
                    Phone = x.Phone,
                    ContractReference = x.ContractReference,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
