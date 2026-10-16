using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.StockLevels
{
    public class GetStockLevelQuery : IRequest<StockLevel>
    {
        public int Id { get; set; }
    }
}
