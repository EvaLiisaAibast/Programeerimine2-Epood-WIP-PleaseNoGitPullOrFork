using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Wishlists
{
    public class GetWishlistQuery : IRequest<OperationResult<WishlistDto>>
    {
        public int Id { get; set; }
    }
}
