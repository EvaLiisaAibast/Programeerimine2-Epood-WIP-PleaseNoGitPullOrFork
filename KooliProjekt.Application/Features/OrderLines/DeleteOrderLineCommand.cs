using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OrderLines
{
    public class DeleteOrderLineCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
