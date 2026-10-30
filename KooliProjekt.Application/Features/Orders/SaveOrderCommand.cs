using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Orders
{
    public class SaveOrderCommand : IRequest<OperationResult<int>>
    {
        public OrderDto Data { get; set; }
    }
}
