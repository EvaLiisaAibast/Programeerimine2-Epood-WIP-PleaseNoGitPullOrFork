using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class GetCustomerGroupQueryHandler : IRequestHandler<GetCustomerGroupQuery, CustomerGroup>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCustomerGroupQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerGroup> Handle(GetCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.CustomerGroups.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
