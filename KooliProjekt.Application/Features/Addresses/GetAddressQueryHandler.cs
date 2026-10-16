using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Addresses
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Address>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAddressQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Addresses.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
