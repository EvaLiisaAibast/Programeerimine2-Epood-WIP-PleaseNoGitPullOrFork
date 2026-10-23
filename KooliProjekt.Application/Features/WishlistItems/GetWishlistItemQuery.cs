using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class GetWishlistItemQuery : IRequest<OperationResult<WishlistItemDto>>
    {
        public int Id { get; set; }
    }
}
