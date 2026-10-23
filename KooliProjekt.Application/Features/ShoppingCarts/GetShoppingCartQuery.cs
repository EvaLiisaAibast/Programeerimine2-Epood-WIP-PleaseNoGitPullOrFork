using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class GetShoppingCartQuery : IRequest<OperationResult<ShoppingCartDto>>
    {
        public int Id { get; set; }
    }
}
