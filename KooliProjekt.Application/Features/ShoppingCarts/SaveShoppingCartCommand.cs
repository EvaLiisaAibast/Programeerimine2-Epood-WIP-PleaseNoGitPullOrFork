using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class SaveShoppingCartCommand : IRequest<OperationResult<int>>
    {
        public ShoppingCartDto Data { get; set; }
    }
}
