using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OrderLines
{
    public class SaveOrderLineCommand : IRequest<OperationResult<int>>
    {
        public OrderLineDto Data { get; set; }
    }
}
