using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Addresses
{
    public class ListAddressesQueryHandler : IRequestHandler<ListAddressesQuery, IEnumerable<Address>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListAddressesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Address>> Handle(ListAddressesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Addresses.ToListAsync(cancellationToken);

            return result;
        }
    }
}
