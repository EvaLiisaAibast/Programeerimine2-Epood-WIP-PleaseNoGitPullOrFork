using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class DeleteShoppingCartCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
