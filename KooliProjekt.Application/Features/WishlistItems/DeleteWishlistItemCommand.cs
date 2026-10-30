using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class DeleteWishlistItemCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
