using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WishlistItems
{
    public class ListWishlistItemsQuery : IRequest<IEnumerable<WishlistItem>>
    {
    }
}
