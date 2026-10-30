using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class SaveOrderStatusHistoryCommand : IRequest<OperationResult<int>>
    {
        public OrderStatusHistoryDto Data { get; set; }
    }
}
