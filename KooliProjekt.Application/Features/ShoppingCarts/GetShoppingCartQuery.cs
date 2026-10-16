using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class GetShoppingCartQuery : IRequest<ShoppingCart>
    {
        public int Id { get; set; }
    }
}
