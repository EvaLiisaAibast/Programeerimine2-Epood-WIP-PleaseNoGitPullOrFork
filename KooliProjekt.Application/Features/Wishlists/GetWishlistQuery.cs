using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Wishlists
{
    public class GetWishlistQuery : IRequest<Wishlist>
    {
        public int Id { get; set; }
    }
}
