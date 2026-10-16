using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.GiftCards
{
    public class ListGiftCardsQuery : IRequest<IEnumerable<GiftCard>>
    {
    }
}
