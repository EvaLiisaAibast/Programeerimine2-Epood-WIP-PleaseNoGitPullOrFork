using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class SaveWishlistItemCommand : IRequest<OperationResult<int>>
    {
        public WishlistItemDto Data { get; set; }
    }
}
