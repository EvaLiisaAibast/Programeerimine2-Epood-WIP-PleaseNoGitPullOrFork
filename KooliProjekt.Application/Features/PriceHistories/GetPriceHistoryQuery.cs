using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PriceHistories
{
    public class GetPriceHistoryQuery : IRequest<PriceHistory>
    {
        public int Id { get; set; }
    }
}
