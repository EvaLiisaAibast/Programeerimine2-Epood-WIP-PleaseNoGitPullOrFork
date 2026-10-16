using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WishlistItems
{
    public class GetWishlistItemQuery : IRequest<WishlistItem>
    {
        public int Id { get; set; }
    }
}
