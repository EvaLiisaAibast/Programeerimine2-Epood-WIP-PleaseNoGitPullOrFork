using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.StockMovements
{
    public class GetStockMovementQuery : IRequest<StockMovement>
    {
        public int Id { get; set; }
    }
}
