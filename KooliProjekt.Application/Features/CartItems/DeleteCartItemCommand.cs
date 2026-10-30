using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CartItems
{
    public class DeleteCartItemCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
