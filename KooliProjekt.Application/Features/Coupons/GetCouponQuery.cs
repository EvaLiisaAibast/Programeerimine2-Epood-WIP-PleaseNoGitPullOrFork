using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Coupons
{
    public class GetCouponQuery : IRequest<Coupon>
    {
        public int Id { get; set; }
    }
}
