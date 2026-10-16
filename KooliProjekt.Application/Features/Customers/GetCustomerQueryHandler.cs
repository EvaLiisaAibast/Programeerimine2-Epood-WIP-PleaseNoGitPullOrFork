using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Customers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCustomerQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Customers.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
