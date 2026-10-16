using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Coupons
{
    public class GetCouponQueryHandler : IRequestHandler<GetCouponQuery, Coupon>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCouponQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Coupon> Handle(GetCouponQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Coupons.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
