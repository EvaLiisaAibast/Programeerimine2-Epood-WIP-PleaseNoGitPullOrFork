using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CartItems
{
    public class GetCartItemQuery : IRequest<CartItem>
    {
        public int Id { get; set; }
    }
}
