using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Coupons
{
    public class GetCouponQuery : IRequest<OperationResult<CouponDto>>
    {
        public int Id { get; set; }
    }
}
