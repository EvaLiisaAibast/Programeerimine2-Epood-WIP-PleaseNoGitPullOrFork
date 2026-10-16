using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Payments
{
    public class ListPaymentsQueryHandler : IRequestHandler<ListPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPaymentsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> Handle(ListPaymentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Payments.ToListAsync(cancellationToken);

            return result;
        }
    }
}
