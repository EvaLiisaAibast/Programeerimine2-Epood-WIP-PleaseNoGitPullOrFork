using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Coupons
{
    public class DeleteCouponCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
