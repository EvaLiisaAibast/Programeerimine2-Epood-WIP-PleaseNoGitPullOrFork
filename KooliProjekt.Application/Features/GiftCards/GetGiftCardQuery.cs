using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class GetGiftCardQuery : IRequest<OperationResult<GiftCardDto>>
    {
        public int Id { get; set; }
    }
}
