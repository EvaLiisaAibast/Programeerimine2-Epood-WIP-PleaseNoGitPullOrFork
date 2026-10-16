using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.GiftCards
{
    public class GetGiftCardQuery : IRequest<GiftCard>
    {
        public int Id { get; set; }
    }
}
