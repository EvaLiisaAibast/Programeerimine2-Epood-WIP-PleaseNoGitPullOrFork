using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CartItems
{
    public class ListCartItemsQuery : IRequest<IEnumerable<CartItem>>
    {
    }
}
