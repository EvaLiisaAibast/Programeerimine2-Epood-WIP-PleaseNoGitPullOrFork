using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.VatRates
{
    public class ListVatRatesQueryHandler : IRequestHandler<ListVatRatesQuery, IEnumerable<VatRate>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListVatRatesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VatRate>> Handle(ListVatRatesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.VatRates.ToListAsync(cancellationToken);

            return result;
        }
    }
}
