using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Coupons
{
    public class SaveCouponCommand : IRequest<OperationResult<int>>
    {
        public CouponDto Data { get; set; }
    }
}
