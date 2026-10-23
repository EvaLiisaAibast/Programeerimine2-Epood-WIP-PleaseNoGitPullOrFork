using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CartItems
{
    public class GetCartItemQuery : IRequest<OperationResult<CartItemDto>>
    {
        public int Id { get; set; }
    }
}
