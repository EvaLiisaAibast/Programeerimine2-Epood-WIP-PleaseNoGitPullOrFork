using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class DeleteGiftCardCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
