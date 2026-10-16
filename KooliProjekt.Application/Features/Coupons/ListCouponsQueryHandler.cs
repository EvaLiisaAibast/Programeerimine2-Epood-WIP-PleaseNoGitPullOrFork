using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Coupons
{
    public class ListCouponsQueryHandler : IRequestHandler<ListCouponsQuery, IEnumerable<Coupon>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCouponsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Coupon>> Handle(ListCouponsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Coupons.ToListAsync(cancellationToken);

            return result;
        }
    }
}
