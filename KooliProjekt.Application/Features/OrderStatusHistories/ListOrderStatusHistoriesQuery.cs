using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class ListOrderStatusHistoriesQuery : IRequest<IEnumerable<OrderStatusHistory>>
    {
    }
}
