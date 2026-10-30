using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Orders
{
    public class DeleteOrderCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
