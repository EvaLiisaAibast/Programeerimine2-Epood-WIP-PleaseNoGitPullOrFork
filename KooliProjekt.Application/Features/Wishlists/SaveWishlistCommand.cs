using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Wishlists
{
    public class SaveWishlistCommand : IRequest<OperationResult<int>>
    {
        public WishlistDto Data { get; set; }
    }
}
