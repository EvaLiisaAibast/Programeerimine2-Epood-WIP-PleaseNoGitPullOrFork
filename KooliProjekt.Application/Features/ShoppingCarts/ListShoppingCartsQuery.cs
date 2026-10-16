using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ShoppingCarts
{
    public class ListShoppingCartsQuery : IRequest<IEnumerable<ShoppingCart>>
    {
    }
}
