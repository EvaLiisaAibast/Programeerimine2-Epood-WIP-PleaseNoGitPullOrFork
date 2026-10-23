using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Addresses
{
    public class ListAddressesQueryHandler : IRequestHandler<ListAddressesQuery, OperationResult<PagedResult<AddressListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListAddressesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<AddressListItemDto>>> Handle(ListAddressesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<AddressListItemDto>>();

            response.Value = await _dbContext.Addresses
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new AddressListItemDto
                {
                    Id = x.Id,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Street = x.Street,
                    HouseNumber = x.HouseNumber,
                    City = x.City,
                    PostalCode = x.PostalCode,
                    IsDefault = x.IsDefault,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
