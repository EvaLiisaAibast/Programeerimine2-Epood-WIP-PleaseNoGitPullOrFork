using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CartItems
{
    public class SaveCartItemCommand : IRequest<OperationResult<int>>
    {
        public CartItemDto Data { get; set; }
    }
}
