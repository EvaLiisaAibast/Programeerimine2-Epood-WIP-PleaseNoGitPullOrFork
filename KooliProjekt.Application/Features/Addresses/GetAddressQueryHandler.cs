using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Addresses
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, OperationResult<AddressDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAddressQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<AddressDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<AddressDto>();

            response.Value = await _dbContext.Addresses
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new AddressDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Country = x.Country,
                    City = x.City,
                    PostalCode = x.PostalCode,
                    Street = x.Street,
                    HouseNumber = x.HouseNumber,
                    Apartment = x.Apartment,
                    IsDefault = x.IsDefault,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
