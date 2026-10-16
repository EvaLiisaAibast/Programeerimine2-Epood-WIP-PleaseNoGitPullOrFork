using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Payments
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, Payment>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPaymentQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Payments.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
