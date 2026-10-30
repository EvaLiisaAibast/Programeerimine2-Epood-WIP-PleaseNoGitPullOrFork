using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class DeleteOrderStatusHistoryCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
