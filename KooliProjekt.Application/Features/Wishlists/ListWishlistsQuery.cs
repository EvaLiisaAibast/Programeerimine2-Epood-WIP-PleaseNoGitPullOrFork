using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Wishlists
{
    public class ListWishlistsQuery : IRequest<IEnumerable<Wishlist>>
    {
    }
}
