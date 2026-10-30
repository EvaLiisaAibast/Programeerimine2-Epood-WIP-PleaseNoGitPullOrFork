using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class SaveGiftCardCommand : IRequest<OperationResult<int>>
    {
        public GiftCardDto Data { get; set; }
    }
}
