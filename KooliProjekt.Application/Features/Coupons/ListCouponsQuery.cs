using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Coupons
{
    public class ListCouponsQuery : IRequest<IEnumerable<Coupon>>
    {
    }
}
