using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Coupons
{
    public class ListCouponsQuery : IRequest<OperationResult<PagedResult<CouponListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
