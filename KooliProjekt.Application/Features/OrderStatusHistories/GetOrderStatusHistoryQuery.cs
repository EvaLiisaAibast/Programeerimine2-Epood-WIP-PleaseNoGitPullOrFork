using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class GetOrderStatusHistoryQuery : IRequest<OrderStatusHistory>
    {
        public int Id { get; set; }
    }
}
