using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class GetOrderStatusHistoryQuery : IRequest<OperationResult<OrderStatusHistoryDto>>
    {
        public int Id { get; set; }
    }
}
